namespace CompaniesHouse.SourceGenerator
{
    /// <summary>
    /// A single configured mapping of a YAML group (parsed via <see cref="MinimalYamlParser"/>,
    /// merged across the submodule and local extras data - see <see cref="EnumDataMerger"/>) to a
    /// generated C# type.
    /// </summary>
    internal sealed class EnumMapEntry
    {
        public EnumMapEntry(string group, string @namespace, string typeName, bool includeDescriptions)
        {
            Group = group;
            Namespace = @namespace;
            TypeName = typeName;
            IncludeDescriptions = includeDescriptions;
        }

        /// <summary>The top-level YAML key, e.g. <c>company_status</c>.</summary>
        public string Group { get; }

        /// <summary>The namespace the generated type is emitted into, e.g. <c>CompaniesHouse.Response</c>.</summary>
        public string Namespace { get; }

        /// <summary>The generated type name, e.g. <c>CompanyStatus</c>.</summary>
        public string TypeName { get; }

        /// <summary>Whether to emit a <c>Description</c> property/lookup for this type.</summary>
        public bool IncludeDescriptions { get; }
    }
}
