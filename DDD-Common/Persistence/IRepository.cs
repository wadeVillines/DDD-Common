namespace DDD.Common.Persistence
{
    public interface IRepository<TEntity, TKey> : IReadRepository<TEntity, TKey>
        where TEntity : Entity<TKey>, IAggregateRoot
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task CommitAsync();
    }
}
