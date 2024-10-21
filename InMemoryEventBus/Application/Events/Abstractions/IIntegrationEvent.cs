using MediatR;

namespace InMemoryEventBus.Application.Events.Abstractions;

public interface IIntegrationEvent : INotification
{
    public Guid Id { get; init; }
}