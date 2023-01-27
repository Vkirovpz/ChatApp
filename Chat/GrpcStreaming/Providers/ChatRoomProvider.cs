using GrpcStreaming.Models;

namespace GrpcStreaming.Providers
{
    public class ChatRoomProvider : IChatRoomProvider
    {
        private static readonly List<ChatRoom> ChatRooms = new List<ChatRoom>
        {
            new ChatRoom(1),
            new ChatRoom(2),
            new ChatRoom(3)
        };

        public ChatRoom GetRandomChatRoom()
        {
            var randomRoom = new Random().Next(ChatRooms.Count);
            return ChatRooms.FirstOrDefault(c => c.Id == randomRoom);
        }

        public ChatRoom GetChatRoomById(int roomId)
        {
            return ChatRooms.FirstOrDefault(c => c.Id == roomId);
        }

        public ChatRoom AddChatRoom()
        {
            var newRoom = new ChatRoom(ChatRooms.Count + 1);
            ChatRooms.Add(newRoom);
            return newRoom;
        }
    }
}
