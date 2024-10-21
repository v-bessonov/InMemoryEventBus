using System.Threading.Channels;
using InMemoryEventBus.Application.Events.Abstractions;

namespace InMemoryEventBus.Infrastructure.Events;

public sealed class InMemoryChannelQueue
{
    private readonly Channel<IIntegrationEvent> _channel = Channel.CreateUnbounded<IIntegrationEvent>();
    
    public ChannelReader<IIntegrationEvent> Reader => _channel.Reader;
    
    public ChannelWriter<IIntegrationEvent> Writer => _channel.Writer;
}