using DDD.Common.Specifications;

namespace DDD.Common.Persistence
{
    public interface IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>, IAggregateRoot
    {
        Task<List<TEntity>> ListAsync();
        Task<List<TEntity>> GetBySpecAsync(Specification<TEntity> spec);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
