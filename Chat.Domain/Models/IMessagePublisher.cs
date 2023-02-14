using System.Threading.Tasks;

namespace Chat.Domain.Models
{
    public interface IMessagePublisher
    {
        Task PublishAsync(Message message);
        Task SubscribeAsync(User user, ChatRoom room);
        Task UnsubscribeAsync(User user);
    }
}
