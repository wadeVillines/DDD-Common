using MediatR;

namespace DDD.Common.Events
{
    public abstract class DomainEventHandler : INotificationHandler<DomainEvent>
    {
        public abstract Task Handle(DomainEvent notification, CancellationToken cancellationToken);
    }
}
