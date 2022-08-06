namespace DDD.Common.Persistence
{
    public interface IPartitionedRepository<TEntity> : IPartitionedReadRepository<TEntity>
        where TEntity : Entity<string>, IAggregateRoot
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task RemoveAsync(string partitionKey, string id, CancellationToken cancellationToken = default);
    }
}
