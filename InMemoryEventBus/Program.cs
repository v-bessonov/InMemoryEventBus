using InMemoryEventBus.Application.Commands;
using InMemoryEventBus.Application.Events.Abstractions;
using InMemoryEventBus.Infrastructure.Events;
using InMemoryEventBus.Infrastructure.HostedServices;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(config
    =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddSingleton<InMemoryChannelQueue>();
builder.Services.AddSingleton<IEventBus, EventBus>();
builder.Services.AddHostedService<IntegrationEventProcessJob>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapDelete("/workout_delete",
        (Guid workoutId, IMediator mediator) => { return mediator.Send(new RemoveWorkoutCommand(workoutId)); })
    .WithName("WorkoutDelete")
    .WithOpenApi();

await app.RunAsync();