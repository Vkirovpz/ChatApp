using System.Threading.Tasks;

namespace Chat.Domain.Models
{
    public interface IMessageWriter
    {
        Task WriteMessageAsync(Message message);

    }
}
