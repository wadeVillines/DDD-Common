﻿using System.Linq.Expressions;

namespace DDD.Common.Specifications
{
    internal class NotSpecification<T> : Specification<T>
    {
        private Specification<T> _spec;

        public NotSpecification(Specification<T> spec)
        {
            _spec = spec;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var expr = _spec.ToExpression();
            var not = Expression.Not(expr);
            return Expression.Lambda<Func<T, bool>>(not, expr.Parameters.Single());
        }
    }
}
