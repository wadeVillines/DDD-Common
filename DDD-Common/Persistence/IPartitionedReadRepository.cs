using DDD.Common.Specifications;

namespace DDD.Common.Persistence
{
    public interface IPartitionedReadRepository<TEntity>
        where TEntity : Entity<string>, IAggregateRoot
    {
        Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default);
        Task<List<TEntity>> ListAsync(string partitionKey, CancellationToken cancellationToken = default);
        Task<List<TEntity>> ListAysnc(Specification<TEntity> spec, CancellationToken cancellationToken = default);
        Task<List<TEntity>> ListAysnc(string partitionKey, Specification<TEntity> spec, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(string partitionKey, string id, CancellationToken cancellationToken = default);
    }
}
