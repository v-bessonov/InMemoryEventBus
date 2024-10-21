
using InMemoryEventBus.Application.Events.Abstractions;
using InMemoryEventBus.Application.Events.DomainEvents;
using MediatR;

namespace InMemoryEventBus.Application.Commands;

public class RemoveWorkoutCommandHandler : IRequestHandler<RemoveWorkoutCommand, bool>
{
    private readonly IEventBus _eventBus;

    public RemoveWorkoutCommandHandler(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public async Task<bool> Handle(RemoveWorkoutCommand request, CancellationToken cancellationToken)
    {
        await _eventBus.PublishAsync(new WorkoutRemovedIntegrationEvent(Guid.NewGuid(), request.WorkoutId), cancellationToken);
        return true;
    }
}
