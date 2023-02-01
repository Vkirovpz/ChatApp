using GrpcStreaming.Models;

namespace GrpcStreaming.Providers
{
    public class ChatRoomProvider : IChatRoomProvider
    {
        private static readonly List<ChatRoom> ChatRooms = new()
        {
            new ChatRoom(1),
            new ChatRoom(2),
            new ChatRoom(3)
        };

        public ChatRoom GetFreeChatRoom()
        {
            return ChatRooms.FirstOrDefault(c => c.UsersInRoom.Count < 20);
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
