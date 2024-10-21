using InMemoryEventBus.Application.Events.DomainEvents;
using MediatR;

namespace InMemoryEventBus.Application.DomainEvents;


public class WorkoutRemovedIntegrationEventHandler : INotificationHandler<WorkoutRemovedIntegrationEvent>
{
    public Task Handle(WorkoutRemovedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}