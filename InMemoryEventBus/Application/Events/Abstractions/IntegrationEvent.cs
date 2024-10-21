namespace InMemoryEventBus.Application.Events.Abstractions;

public abstract record IntegrationEvent(Guid Id) : IIntegrationEvent
{
    
}