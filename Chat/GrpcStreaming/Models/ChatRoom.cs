namespace GrpcStreaming.Models
{
    public class ChatRoom
    {
        public int Id { get; }
        public List<User> UsersInRoom { get; }
        public ChatRoom(int id)
        {
            Id = id;
            UsersInRoom = new List<User>();
        }
    }
}
