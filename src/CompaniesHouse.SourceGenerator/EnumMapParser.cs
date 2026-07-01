using System;
using System.Collections.Generic;

namespace CompaniesHouse.SourceGenerator
{
    /// <summary>
    /// Parses the <c>enum-map.txt</c> configuration file that declares which YAML groups
    /// (see <see cref="MinimalYamlParser"/>) should be generated, and into which type.
    /// </summary>
    /// <remarks>
    /// Format: one entry per non-blank, non-comment (<c>#</c>) line, pipe-delimited:
    /// <code>group|namespace|TypeName|includeDescriptions</code>
    /// e.g. <c>company_status|CompaniesHouse.Response|CompanyStatus|true</c>.
    /// </remarks>
    internal static class EnumMapParser
    {
        public static IReadOnlyList<EnumMapEntry> Parse(string text)
        {
            var entries = new List<EnumMapEntry>();

            foreach (var rawLine in text.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n'))
            {
                var line = rawLine.Trim();
                if (line.Length == 0 || line.StartsWith("#", StringComparison.Ordinal))
                {
                    continue;
                }

                var parts = line.Split('|');
                if (parts.Length != 4)
                {
                    continue;
                }

                var group = parts[0].Trim();
                var @namespace = parts[1].Trim();
                var typeName = parts[2].Trim();
                var includeDescriptions = bool.TryParse(parts[3].Trim(), out var parsed) && parsed;

                entries.Add(new EnumMapEntry(group, @namespace, typeName, includeDescriptions));
            }

            return entries;
        }
    }
}
