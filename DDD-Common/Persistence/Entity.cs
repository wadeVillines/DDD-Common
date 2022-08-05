using DDD.Common.Events;
using System.Text.Json.Serialization;

namespace DDD.Common.Persistence
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        private List<DomainEvent> _domainEvents;

        public Entity()
        {
            _domainEvents = new List<DomainEvent>();
        }

        public Entity(TId id) : this()
        {
            if (Equals(id, default(TId)))
                throw new Exception("The ID of an entity cannot be a default value.");

            Id = id;
        }

        public TId Id { get; set; }

        [JsonIgnore]
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents;
        
        public void AddDomainEvent(DomainEvent domainEvent)
        {
            if (domainEvent == null)
                return;

            _domainEvents.Add(domainEvent);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TId> other)
                return false;

            return Equals(other);
        }

        public bool Equals(Entity<TId>? other)
        {
            if (other == null)
                return false;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}