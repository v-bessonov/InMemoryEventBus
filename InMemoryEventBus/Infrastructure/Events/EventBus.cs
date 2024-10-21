using InMemoryEventBus.Application.Events.Abstractions;

namespace InMemoryEventBus.Infrastructure.Events;

public sealed class EventBus : IEventBus
{
    private readonly InMemoryChannelQueue _queue;

    public EventBus(InMemoryChannelQueue queue)
    {
        _queue = queue;
    }
    public async Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default) where T : class, IIntegrationEvent
    {
        await _queue.Writer.WriteAsync(integrationEvent, cancellationToken);
    }
}