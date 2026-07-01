using System.Collections.Generic;
using System.Text;

namespace CompaniesHouse.SourceGenerator
{
    /// <summary>
    /// Converts a Companies House wire value (e.g. <c>voluntary-arrangement</c>) into a
    /// PascalCase C# identifier suitable for a static member name (e.g. <c>VoluntaryArrangement</c>).
    /// </summary>
    internal static class MemberNameGenerator
    {
        /// <summary>
        /// A small set of hand-picked overrides for wire values that the naive
        /// PascalCase conversion would turn into an awkward or invalid identifier.
        /// Keyed by wire value, ordinal.
        /// </summary>
        private static readonly Dictionary<string, string> Overrides =
            new Dictionary<string, string>(System.StringComparer.Ordinal)
            {
                [""] = "Empty",
            };

        public static string ToMemberName(string wireValue)
        {
            if (Overrides.TryGetValue(wireValue, out var overridden))
            {
                return overridden;
            }

            var sb = new StringBuilder();
            var capitaliseNext = true;

            foreach (var c in wireValue)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    capitaliseNext = true;
                    continue;
                }

                sb.Append(capitaliseNext ? char.ToUpperInvariant(c) : c);
                capitaliseNext = false;
            }

            var result = sb.ToString();

            if (result.Length == 0)
            {
                return "Empty";
            }

            if (char.IsDigit(result[0]))
            {
                result = "_" + result;
            }

            return result;
        }
    }
}
