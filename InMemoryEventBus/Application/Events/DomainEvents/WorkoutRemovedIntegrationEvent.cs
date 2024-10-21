using InMemoryEventBus.Application.Events.Abstractions;

namespace InMemoryEventBus.Application.Events.DomainEvents;

public record WorkoutRemovedIntegrationEvent(Guid Id, Guid WorkoutId) : IntegrationEvent(Id);
