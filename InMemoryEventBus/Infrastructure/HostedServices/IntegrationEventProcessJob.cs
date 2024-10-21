using InMemoryEventBus.Application.Events.Abstractions;
using InMemoryEventBus.Infrastructure.Events;
using MediatR;

namespace InMemoryEventBus.Infrastructure.HostedServices;

public class IntegrationEventProcessJob : BackgroundService

{
    private readonly InMemoryChannelQueue _queue;
    private readonly IPublisher _publisher;
    private readonly ILogger<IntegrationEventProcessJob> _logger;

    public IntegrationEventProcessJob(InMemoryChannelQueue queue, IPublisher publisher,
        ILogger<IntegrationEventProcessJob> logger)
    {
        _queue = queue;
        _publisher = publisher;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (IIntegrationEvent integrationEvent in _queue.Reader.ReadAllAsync(stoppingToken))
        {
            _logger.LogInformation($"Processing integration event: {integrationEvent.Id}");
            await _publisher.Publish(integrationEvent, stoppingToken);
            _logger.LogInformation($"Processed integration event: {integrationEvent.Id}");
        }
    }
}