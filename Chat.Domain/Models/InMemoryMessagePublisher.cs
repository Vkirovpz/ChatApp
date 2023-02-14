using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Chat.Domain.Models
{
    public class InMemoryMessagePublisher : IMessagePublisher
    {
        private readonly IList<IMessageWriter> messageWriters;

        public InMemoryMessagePublisher(IList<IMessageWriter> messageWriters)
        {
            this.messageWriters = messageWriters ?? throw new System.ArgumentNullException(nameof(messageWriters));
        }

        public async Task PublishAsync(Message message)
        {
            foreach (var writer in messageWriters)
            {
                await writer.WriteMessageAsync(message);
            }
        }

        public Task SubscribeAsync(User user, ChatRoom room)
        {
            if (messageWriters.Contains(user.MessageWriter) == false)
                messageWriters.Add(user.MessageWriter);

            return Task.CompletedTask;
        }

        public Task UnsubscribeAsync(User user)
        {
            if (messageWriters.Contains(user.MessageWriter) == false)
                messageWriters.Remove(user.MessageWriter);

            return Task.CompletedTask;
        }
    }
}
