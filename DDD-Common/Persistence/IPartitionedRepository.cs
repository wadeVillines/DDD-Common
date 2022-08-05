using DDD.Common;
using DDD.Common.Persistence;
using DDD.Common.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_Common.Persistence
{
    public interface IPartitionedRepository<TEntity>
        where TEntity : Entity<string>, IAggregateRoot
    {
        Task<List<TEntity>> ListAsync();
        Task<List<TEntity>> ListAsync(string partitionKey);
        Task<List<TEntity>> GetBySpecAsync(Specification<TEntity> spec);
        Task<List<TEntity>> GetBySpecAsync(string partitionKey, Specification<TEntity> spec);
        Task<TEntity> GetByIdAsync(string partitionKey, string id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(string partitionKey, string id);
    }
}
