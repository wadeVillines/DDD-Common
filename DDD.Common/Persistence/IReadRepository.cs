using DDD.Common.Specifications;

namespace DDD.Common.Persistence
{
    public interface IReadRepository<TEntity, TKey>
        where TEntity : Entity<TKey>, IAggregateRoot
    {
        Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default);
        Task<List<TEntity>> ListAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
    }
}
