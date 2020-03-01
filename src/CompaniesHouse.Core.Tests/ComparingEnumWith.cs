using System;
using System.Collections.Generic;
using CompaniesHouse.Core.Tests.MapProviders;
using FluentAssertions.Equivalency;

namespace CompaniesHouse.Core.Tests
{
    public class ComparingEnumWith<TMapProvider, TEnum> : IEquivalencyStep
        where TMapProvider : IEnumDataMapProvider<TEnum>, new()
        where TEnum : struct
    {
        private readonly IReadOnlyDictionary<string, TEnum> _dictionary;
        private readonly Type _enumType;

        public ComparingEnumWith()
        {
            _enumType = typeof(TEnum);
            if (!_enumType.IsEnum)
            {
                throw new ArgumentException("TEnum must be an enum");
            }

            var provider = Activator.CreateInstance<TMapProvider>();

            _dictionary = provider.Map;
        }

        public bool CanHandle(IEquivalencyValidationContext context, IEquivalencyAssertionOptions config)
        {
            var subjectType = config.GetExpectationType(context);

            return subjectType != null && subjectType == _enumType && context.Expectation is string;
        }

        public bool Handle(IEquivalencyValidationContext context, IEquivalencyValidator parent, IEquivalencyAssertionOptions config)
        {
            var expected = _dictionary[(string)context.Expectation];

            return ((TEnum)context.Subject).Equals(expected);
        }
    }
}