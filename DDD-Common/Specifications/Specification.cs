using System.Linq.Expressions;

namespace DDD.Common.Specifications
{
    public abstract class Specification<T>
    {
        public static readonly Specification<T> All = new IdentitySpecification<T>();

        public bool IsSatisfiedBy(T entity) => ToExpression().Compile()(entity);

        public abstract Expression<Func<T, bool>> ToExpression();

        public Specification<T> And(Specification<T> spec)
        {
            if (this == All)
                return spec;
            if (spec == All)
                return this;

            return new AndSpecification<T>(this, spec);
        }

        public Specification<T> Or(Specification<T> spec)
        {
            if (this == All || spec == All)
                return All;

            return new OrSpecification<T>(this, spec);
        }

        public Specification<T> Not(Specification<T> spec) => new NotSpecification<T>(spec);
    }
}
