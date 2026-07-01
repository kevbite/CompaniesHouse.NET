using System.Collections.Generic;

namespace CompaniesHouse.SourceGenerator
{
    /// <summary>
    /// A minimal, hand-rolled parser for the specific YAML subset used by the
    /// Companies House <c>api-enumerations</c> reference data and our own
    /// <c>enumerations/extra/*.yml</c> overlay files.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Only the shape actually used by these files is supported:
    /// </para>
    /// <code>
    /// group_one:
    ///     'wire-value' : "Friendly description"
    ///     'other-value': "Another description"
    /// group_two:
    ///     'value': ''
    /// </code>
    /// <para>
    /// Top-level (column 0) keys are group names. Indented lines under a group
    /// are <c>'key' : "value"</c> pairs, where the key and value may each be
    /// single- or double-quoted (or left bare). Blank lines, lines consisting
    /// solely of <c>---</c>, and lines whose first non-whitespace character is
    /// <c>#</c> are ignored. This is intentionally not a general-purpose YAML
    /// parser - it will not handle nested mappings, sequences, block scalars,
    /// flow style, anchors, or multi-line values.
    /// </para>
    /// </remarks>
    internal static class MinimalYamlParser
    {
        /// <summary>
        /// Parses <paramref name="yaml"/> into an ordered list of top-level groups,
        /// each with its ordered list of wire-value/description entries.
        /// </summary>
        public static IReadOnlyList<YamlGroup> Parse(string yaml)
        {
            var groups = new List<YamlGroup>();
            YamlGroup? current = null;

            foreach (var rawLine in SplitLines(yaml))
            {
                var line = rawLine;

                // Strip trailing comments/whitespace, but only when not inside quotes -
                // none of our real files put '#' inside a quoted value, so a simple
                // "not currently in a quote" scan is sufficient here.
                line = StripComment(line);

                if (line.Trim().Length == 0)
                {
                    continue;
                }

                if (line.Trim() == "---")
                {
                    continue;
                }

                if (!char.IsWhiteSpace(line[0]))
                {
                    // Top-level line -> new group. Format: "group_name:"
                    var name = line.TrimEnd().TrimEnd(':').Trim();
                    if (name.Length == 0)
                    {
                        continue;
                    }

                    current = new YamlGroup(name);
                    groups.Add(current);
                    continue;
                }

                if (current is null)
                {
                    // Indented content before any group header - ignore.
                    continue;
                }

                var trimmed = line.Trim();
                var colonIndex = FindUnquotedColon(trimmed);
                if (colonIndex < 0)
                {
                    continue;
                }

                var rawKey = trimmed.Substring(0, colonIndex).Trim();
                var rawValue = trimmed.Substring(colonIndex + 1).Trim();

                var key = Unquote(rawKey);
                var value = Unquote(rawValue);

                current.Entries.Add(new YamlEntry(key, value));
            }

            return groups;
        }

        private static IEnumerable<string> SplitLines(string text)
        {
            return text.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n');
        }

        private static string StripComment(string line)
        {
            var inSingleQuote = false;
            var inDoubleQuote = false;

            for (var i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (c == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                }
                else if (c == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                }
                else if (c == '#' && !inSingleQuote && !inDoubleQuote)
                {
                    return line.Substring(0, i);
                }
            }

            return line;
        }

        private static int FindUnquotedColon(string text)
        {
            var inSingleQuote = false;
            var inDoubleQuote = false;

            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];
                if (c == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                }
                else if (c == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                }
                else if (c == ':' && !inSingleQuote && !inDoubleQuote)
                {
                    return i;
                }
            }

            return -1;
        }

        private static string Unquote(string text)
        {
            if (text.Length >= 2)
            {
                if ((text[0] == '\'' && text[text.Length - 1] == '\'') ||
                    (text[0] == '"' && text[text.Length - 1] == '"'))
                {
                    return text.Substring(1, text.Length - 2);
                }
            }

            return text;
        }
    }

    /// <summary>A top-level YAML group (e.g. <c>company_status</c>) and its ordered entries.</summary>
    internal sealed class YamlGroup
    {
        public YamlGroup(string name)
        {
            Name = name;
            Entries = new List<YamlEntry>();
        }

        public string Name { get; }

        public List<YamlEntry> Entries { get; }
    }

    /// <summary>A single <c>'wire-value': "description"</c> entry within a <see cref="YamlGroup"/>.</summary>
    internal readonly struct YamlEntry
    {
        public YamlEntry(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }

        public string Value { get; }
    }
}
