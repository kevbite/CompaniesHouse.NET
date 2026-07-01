using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace CompaniesHouse.SourceGenerator.Tests
{
    /// <summary>A minimal in-memory <see cref="AdditionalText"/> for driving the generator in tests.</summary>
    internal sealed class InMemoryAdditionalText : AdditionalText
    {
        private readonly SourceText _text;

        public InMemoryAdditionalText(string path, string content)
        {
            Path = path;
            _text = SourceText.From(content, System.Text.Encoding.UTF8);
        }

        public override string Path { get; }

        public override SourceText GetText(System.Threading.CancellationToken cancellationToken = default) => _text;
    }
}
