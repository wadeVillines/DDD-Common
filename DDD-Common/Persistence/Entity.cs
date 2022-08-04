namespace DDD.Common.Persistence
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public Entity()
        { }

        public Entity(TId id)
        {
            if (Equals(id, default(TId)))
                throw new Exception("The ID of an entity cannot be a default value.");

            Id = id;
        }

        public TId Id { get; set; }

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