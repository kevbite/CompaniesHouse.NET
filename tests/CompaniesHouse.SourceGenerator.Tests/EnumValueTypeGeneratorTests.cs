using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using CompaniesHouse.SourceGenerator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Shouldly;
using Xunit;

namespace CompaniesHouse.SourceGenerator.Tests
{
    /// <summary>
    /// End-to-end tests that run <see cref="EnumValueTypeGenerator"/> through a real
    /// <see cref="CSharpGeneratorDriver"/> with in-memory <see cref="AdditionalText"/>s standing
    /// in for the api-enumerations submodule + extras + enum-map.txt config.
    /// </summary>
    public class EnumValueTypeGeneratorTests
    {
        [Fact]
        public void GeneratesAValueTypeAndConverterForAConfiguredGroup()
        {
            var additionalFiles = new[]
            {
                new InMemoryAdditionalText(@"external\api-enumerations\constants.yml", """
                    company_status:
                        'active' : "Active"
                        'dissolved' : "Dissolved"
                    """),
                new InMemoryAdditionalText(@"enum-map.txt", "company_status|CompaniesHouse.Response|CompanyStatus|true"),
            };

            var generated = RunGenerator(additionalFiles);

            generated.ShouldContainKey("CompanyStatus.g.cs");
            generated["CompanyStatus.g.cs"].ShouldContain("public readonly record struct CompanyStatus");
            generated["CompanyStatus.g.cs"].ShouldContain("public static CompanyStatus Active => new(\"active\");");
            generated["CompanyStatus.g.cs"].ShouldContain("public static CompanyStatus Dissolved => new(\"dissolved\");");
            generated["CompanyStatus.g.cs"].ShouldContain("[\"active\"] = \"Active\"");

            generated.ShouldContainKey("CompanyStatusJsonConverter.g.cs");
            generated["CompanyStatusJsonConverter.g.cs"].ShouldContain("public sealed class CompanyStatusJsonConverter : JsonConverter<CompanyStatus>");
        }

        [Fact]
        public void ExtrasOverlayOverridesAndAppendsToSubmoduleData()
        {
            var additionalFiles = new[]
            {
                new InMemoryAdditionalText(@"external\api-enumerations\constants.yml", """
                    company_status:
                        'active' : "Active"
                    """),
                new InMemoryAdditionalText(@"C:\repo\enumerations\extra\company_status.yml", """
                    company_status:
                        'active' : "Overridden"
                        'closed-on' : "Closed On"
                    """),
                new InMemoryAdditionalText(@"enum-map.txt", "company_status|CompaniesHouse.Response|CompanyStatus|true"),
            };

            var generated = RunGenerator(additionalFiles);

            generated["CompanyStatus.g.cs"].ShouldContain("[\"active\"] = \"Overridden\"");
            generated["CompanyStatus.g.cs"].ShouldContain("public static CompanyStatus ClosedOn => new(\"closed-on\");");
        }

        [Fact]
        public void DoesNotGenerateAMemberForAnEmptyStringWireValue()
        {
            var additionalFiles = new[]
            {
                new InMemoryAdditionalText(@"external\api-enumerations\constants.yml", """
                    company_status_detail:
                        'active' : ""
                        'dissolved' : ""
                    """),
                new InMemoryAdditionalText(@"enum-map.txt", "company_status_detail|CompaniesHouse.Response|CompanyStatusDetail|false"),
            };

            var generated = RunGenerator(additionalFiles);

            generated["CompanyStatusDetail.g.cs"].ShouldNotContain("public static CompanyStatusDetail Empty");
            generated["CompanyStatusDetail.g.cs"].ShouldNotContain("Description =>");
        }

        [Fact]
        public void ReportsADiagnosticWhenAConfiguredGroupIsNotFoundInAnyYaml()
        {
            var additionalFiles = new[]
            {
                new InMemoryAdditionalText(@"external\api-enumerations\constants.yml", """
                    company_status:
                        'active' : "Active"
                    """),
                new InMemoryAdditionalText(@"enum-map.txt", "no_such_group|CompaniesHouse.Response|NoSuchGroup|false"),
            };

            var diagnostics = RunGeneratorAndGetDiagnostics(additionalFiles);

            diagnostics.ShouldContain(d => d.Id == "CHENUM001");
        }

        private static Dictionary<string, string> RunGenerator(IEnumerable<InMemoryAdditionalText> additionalFiles)
        {
            var compilation = CreateCompilation();
            var generator = new EnumValueTypeGenerator();
            GeneratorDriver driver = CSharpGeneratorDriver.Create(new IIncrementalGenerator[] { generator });
            driver = driver.AddAdditionalTexts(additionalFiles.Cast<AdditionalText>().ToImmutableArray());

            driver = driver.RunGeneratorsAndUpdateCompilation(compilation, out _, out var runDiagnostics);
            var runResult = driver.GetRunResult();

            var faulted = runResult.Results.FirstOrDefault(r => r.Exception is not null);
            if (faulted.Exception is not null)
            {
                throw faulted.Exception;
            }

            if (runDiagnostics.Any())
            {
                throw new System.Exception("Generator diagnostics: " + string.Join("\n", runDiagnostics));
            }

            return runResult.Results
                .Where(r => !r.GeneratedSources.IsDefault)
                .SelectMany(r => r.GeneratedSources)
                .ToDictionary(s => s.HintName, s => s.SourceText.ToString());
        }

        private static List<Diagnostic> RunGeneratorAndGetDiagnostics(IEnumerable<InMemoryAdditionalText> additionalFiles)
        {
            var compilation = CreateCompilation();
            var generator = new EnumValueTypeGenerator();
            GeneratorDriver driver = CSharpGeneratorDriver.Create(new IIncrementalGenerator[] { generator });
            driver = driver.AddAdditionalTexts(additionalFiles.Cast<AdditionalText>().ToImmutableArray());

            driver = driver.RunGeneratorsAndUpdateCompilation(compilation, out _, out var diagnostics);

            return diagnostics.ToList();
        }

        private static CSharpCompilation CreateCompilation()
        {
            return CSharpCompilation.Create(
                "CompaniesHouse.SourceGenerator.Tests.GeneratedAssembly",
                references: new[]
                {
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                },
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }
    }
}
