using System.Linq.Expressions;

namespace DDD.Common.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();
        public bool IsSatisfiedBy(T entity) => ToExpression().Compile()(entity);
        public Specification<T> And(Specification<T> spec) => new AndSpecification<T>(this, spec);
        public Specification<T> Or(Specification<T> spec) => new OrSpecification<T>(this, spec);
        public Specification<T> Not(Specification<T> spec) => new NotSpecification<T>(spec);
    }
}
