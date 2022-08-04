using System.Linq.Expressions;

namespace DDD.Common.Specifications
{
    internal class AndSpecification<T> : Specification<T>
    {
        private Specification<T> _left;
        private Specification<T> _right;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var left = _left.ToExpression();
            var right = _right.ToExpression();
            var and = Expression.AndAlso(left, right);
            return Expression.Lambda<Func<T, bool>>(and, left.Parameters.Single());
        }
    }
}
