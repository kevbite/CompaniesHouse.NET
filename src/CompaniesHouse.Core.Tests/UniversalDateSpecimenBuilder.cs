using System;
using System.Linq.Expressions;
using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;

namespace CompaniesHouse.Core.Tests
{
    public class UniversalDateSpecimenBuilder<TEntity> : ISpecimenBuilder
    {
        private readonly PropertyInfo _prop;

        public UniversalDateSpecimenBuilder(Expression<Func<TEntity, DateTime>> getter)
        {
            _prop = (PropertyInfo)((MemberExpression)getter.Body).Member;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;

            if (pi != null && AreEquivalent(pi, _prop))
            {
                return context.Create<DateTime>().ToUniversalTime().Date;
            }

            return new NoSpecimen();
        }

        private bool AreEquivalent(PropertyInfo a, PropertyInfo b)
        {
            return a.DeclaringType == b.DeclaringType
                   && a.Name == b.Name;
        }
    }
}