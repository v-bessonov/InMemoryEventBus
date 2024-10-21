
using MediatR;

namespace InMemoryEventBus.Application.Commands;

public record RemoveWorkoutCommand(Guid WorkoutId) : IRequest<bool>;
