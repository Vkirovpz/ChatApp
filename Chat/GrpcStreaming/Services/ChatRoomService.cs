using Grpc.Core;
using GrpcStreaming.Providers;

namespace GrpcStreaming.Services
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly IChatRoomProvider _chatRoomProvider;

        public ChatRoomService(IChatRoomProvider chatRoomProvider)
        {
            _chatRoomProvider = chatRoomProvider;
        }

        public async Task BroadcastMessageAsync(ChatMessage message)
        {
            var chatRoom = _chatRoomProvider.GetChatRoomById(message.RoomId);
            foreach (var user in chatRoom.UsersInRoom)
            {
                await user.Stream.WriteAsync(message);
                Console.WriteLine($"Sent message from {message.UserName} to {user.Name}");
            }
        }

        public Task<int> AddUserToChatRoomAsync(User user)
        {
            var room = _chatRoomProvider.GetFreeChatRoom();
            room.UsersInRoom.Add(new Models.User
            {
                Name = user.Name,
                Id = Guid.Parse(user.Id)
            });
            return Task.FromResult(room.Id);
        }

        public void ConnectUserToChatRoom(int roomId, Guid userId, IAsyncStreamWriter<ChatMessage> responseStream)
        {
            _chatRoomProvider.GetChatRoomById(roomId).UsersInRoom.FirstOrDefault(u => u.Id == userId).Stream = responseStream;
        }

        public void DisconnectUser(int roomId, Guid userId)
        {
            var room = _chatRoomProvider.GetChatRoomById(roomId);
            room.UsersInRoom.Remove(room.UsersInRoom.FirstOrDefault(c => c.Id == userId));
        }
    }
}
