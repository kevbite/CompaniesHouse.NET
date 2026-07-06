using System;
using System.Collections.Generic;
using System.Linq;

namespace CompaniesHouse.SourceGenerator
{
    /// <summary>
    /// Merges the parsed <see cref="YamlGroup"/> data from multiple YAML sources into a single
    /// per-group, ordered set of wire-value/description entries.
    /// </summary>
    /// <remarks>
    /// Merge order matters: sources are merged in the order they're passed in, and a later
    /// source's entry for the same group + wire value overrides an earlier one's description
    /// (and appends brand new wire values/groups). Callers should pass the submodule's parsed
    /// files first, and the local <c>enumerations/extra/*.yml</c> overlay files last, per
    /// <c>enumerations/extra/README.md</c>.
    /// </remarks>
    internal static class EnumDataMerger
    {
        public static IReadOnlyDictionary<string, MergedGroup> Merge(IEnumerable<IReadOnlyList<YamlGroup>> sourcesInOrder)
        {
            var groups = new Dictionary<string, MergedGroup>(StringComparer.Ordinal);

            foreach (var source in sourcesInOrder)
            {
                foreach (var group in source)
                {
                    if (!groups.TryGetValue(group.Name, out var merged))
                    {
                        merged = new MergedGroup(group.Name);
                        groups[group.Name] = merged;
                    }

                    foreach (var entry in group.Entries)
                    {
                        merged.Set(entry.Key, entry.Value);
                    }
                }
            }

            return groups;
        }
    }

    /// <summary>The merged, de-duplicated entries for a single enum group, in first-seen order.</summary>
    internal sealed class MergedGroup
    {
        private readonly List<string> _order = new List<string>();
        private readonly Dictionary<string, string> _descriptions = new Dictionary<string, string>(StringComparer.Ordinal);

        public MergedGroup(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Set(string wireValue, string description)
        {
            if (!_descriptions.ContainsKey(wireValue))
            {
                _order.Add(wireValue);
            }

            _descriptions[wireValue] = description;
        }

        /// <summary>Wire values in first-seen order (submodule order, then any extras-only additions).</summary>
        public IReadOnlyList<string> WireValues => _order;

        public string GetDescription(string wireValue) => _descriptions[wireValue];

        public IEnumerable<KeyValuePair<string, string>> Entries => _order.Select(v => new KeyValuePair<string, string>(v, _descriptions[v]));
    }
}
