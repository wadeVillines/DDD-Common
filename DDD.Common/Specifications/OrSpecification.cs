using System.Linq.Expressions;

namespace DDD.Common.Specifications
{
    internal class OrSpecification<T> : Specification<T>
    {
        private Specification<T> _left;
        private Specification<T> _right;

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var left = _left.ToExpression();
            var right = _right.ToExpression();
            var or = Expression.OrElse(left, right);
            return Expression.Lambda<Func<T, bool>>(or, left.Parameters.Single());
        }
    }
}
