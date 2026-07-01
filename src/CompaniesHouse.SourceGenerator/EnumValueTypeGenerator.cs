using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace CompaniesHouse.SourceGenerator
{
    /// <summary>
    /// Incremental generator that reads the Companies House <c>api-enumerations</c> YAML
    /// (submodule, plan 05) and our local <c>enumerations/extra/*.yml</c> overlay, merges them
    /// (submodule first, extras override/append), and emits the string-backed value types
    /// (plan 03) configured in <c>enum-map.txt</c>.
    /// </summary>
    /// <remarks>
    /// This generator is referenced from <c>CompaniesHouse.csproj</c> as a build-time-only
    /// analyzer (<c>OutputItemType="Analyzer"</c>, <c>ReferenceOutputAssembly="false"</c>) - it
    /// is never shipped to consumers. The shipped package contains only the concrete generated
    /// types, compiled straight into <c>CompaniesHouse.dll</c>.
    /// </remarks>
    [Generator(LanguageNames.CSharp)]
    public sealed class EnumValueTypeGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var yamlFiles = context.AdditionalTextsProvider
                .Where(static file => file.Path.EndsWith(".yml", StringComparison.OrdinalIgnoreCase))
                .Where(static file => !file.Path.Replace('\\', '/').Contains("/enum-map"))
                .Select(static (file, ct) => (file.Path, Text: file.GetText(ct)?.ToString() ?? string.Empty));

            var enumMapFiles = context.AdditionalTextsProvider
                .Where(static file => System.IO.Path.GetFileName(file.Path).Equals("enum-map.txt", StringComparison.OrdinalIgnoreCase))
                .Select(static (file, ct) => file.GetText(ct)?.ToString() ?? string.Empty);

            var combined = yamlFiles.Collect().Combine(enumMapFiles.Collect());

            context.RegisterSourceOutput(combined, static (spc, data) =>
            {
                var (yamlSources, enumMapTexts) = data;
                Execute(spc, yamlSources, enumMapTexts);
            });
        }

        private static void Execute(
            SourceProductionContext context,
            ImmutableArray<(string Path, string Text)> yamlSources,
            ImmutableArray<string> enumMapTexts)
        {
            if (enumMapTexts.Length == 0)
            {
                return;
            }

            var mapEntries = enumMapTexts.SelectMany(EnumMapParser.Parse).ToList();
            if (mapEntries.Count == 0)
            {
                return;
            }

            // Submodule files first, then our local extras overlay - so extras override/append.
            // See enumerations/extra/README.md for the documented merge rule.
            var orderedYaml = yamlSources
                .OrderBy(static f => IsExtraFile(f.Path) ? 1 : 0)
                .ThenBy(static f => f.Path, StringComparer.Ordinal)
                .Select(static f => MinimalYamlParser.Parse(f.Text))
                .ToList();

            var mergedGroups = EnumDataMerger.Merge(orderedYaml);

            foreach (var mapEntry in mapEntries)
            {
                if (!mergedGroups.TryGetValue(mapEntry.Group, out var group))
                {
                    context.ReportDiagnostic(Diagnostic.Create(
                        MissingGroupDescriptor,
                        Location.None,
                        mapEntry.Group,
                        mapEntry.TypeName));
                    continue;
                }

                var valueTypeSource = ValueTypeEmitter.EmitValueType(mapEntry, group);
                context.AddSource($"{mapEntry.TypeName}.g.cs", SourceText.From(valueTypeSource, System.Text.Encoding.UTF8));

                var converterSource = ValueTypeEmitter.EmitJsonConverter(mapEntry);
                context.AddSource($"{mapEntry.TypeName}JsonConverter.g.cs", SourceText.From(converterSource, System.Text.Encoding.UTF8));
            }
        }

        private static bool IsExtraFile(string path) =>
            path.Replace('\\', '/').Contains("/enumerations/extra/");

        private static readonly DiagnosticDescriptor MissingGroupDescriptor = new DiagnosticDescriptor(
            id: "CHENUM001",
            title: "Enum group not found in api-enumerations data",
            messageFormat: "enum-map.txt configures group '{0}' -> '{1}' but no such group was found in the submodule or extras YAML",
            category: "CompaniesHouse.SourceGenerator",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);
    }
}
