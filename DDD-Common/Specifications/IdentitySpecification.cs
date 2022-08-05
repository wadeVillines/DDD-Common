using System.Linq.Expressions;

namespace DDD.Common.Specifications
{
    internal class IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}
