using DDD.Common.Events;
using DDD.Common.Specifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DDD.Common.Persistence.EntityFramework
{
    public abstract class EFRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>, IAggregateRoot
    {
        private readonly DbContext _context;
        private readonly IMediator _mediator;

        public EFRepositoryBase(DbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await CommitAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<List<TEntity>> ListAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().Where(specification.ToExpression()).ToListAsync(cancellationToken);
        }

        public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Remove(entity);
            await CommitAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Update(entity);
            await CommitAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            // gather all domain events
            var entities = _context.ChangeTracker.Entries<TEntity>()
                .Select(x => x.Entity)
                .ToList();

            var domainEvents = entities
                .SelectMany(x => x.DomainEvents)
                .ToList();

            entities.ForEach(x => x.ClearDomainEvents());

            // persist entity to database
            await _context.SaveChangesAsync(cancellationToken);

            // publish domain events
            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent, cancellationToken);

            // TODO: implement transactional outbox pattern to prevent lost events
        }
    }
}
