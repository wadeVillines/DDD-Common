namespace DDD.Common.Persistence
{
    public interface IRepository<TEntity, TKey> : IReadRepository<TEntity, TKey>
        where TEntity : Entity<TKey>, IAggregateRoot
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
