using MediatR;

namespace DDD.Common.Events
{
    public abstract class DomainEvent : INotification
    {
        public DomainEvent()
        {
            DateOccurred = DateTimeOffset.UtcNow;
        }

        public DateTimeOffset DateOccurred { get; protected set; }
    }
}
