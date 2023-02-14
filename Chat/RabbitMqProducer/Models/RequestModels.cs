namespace RabbitMqProducer.Models
{
    public class RequestModels
    {
        public record CreateRoomRequest(string username, string roomName);
        public record JoinRoomRequest(string username, string roomName);
        public record SendMessageRequest(string username, string message);
    }
}
