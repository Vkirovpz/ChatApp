using Chat.Domain;
using Chat.Domain.Models;

namespace Chat.Grpc.Server.Services
{
    public class GrpcMessagePublisher : IMessagePublisher
    {
        private IList<IMessageWriter> messageWriters = new List<IMessageWriter>();

        public async Task PublishAsync(Message message)
        {
            foreach (var writer in messageWriters)
            {
                await writer.WriteMessageAsync(message);
            }
        }

        public Task SubscribeAsync(User user, ChatRoom room)
        {
            messageWriters.Add(user.MessageWriter);
            return Task.CompletedTask;
        }

        public Task UnsubscribeAsync(User user)
        {
            messageWriters.Remove(user.MessageWriter);
            return Task.CompletedTask;
        }
    }
}