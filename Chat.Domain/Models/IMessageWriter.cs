namespace Chat.Domain.Models
{
    public interface IMessageWriter
    {
        void Write(string message);

        void WriteMessage(Message message);
    }
}
