using DDD.Common.Specifications;

namespace DDD.Common.Persistence
{
    public interface IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>, IAggregateRoot
    {
        Task<List<TEntity>> List();
        Task<List<TEntity>> GetBySpec(Specification<TEntity> spec);
        Task<TEntity> GetById(TKey id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
    }
}
