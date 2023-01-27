using Grpc.Core;
using GrpcStreaming.Models;

namespace GrpcStreaming.Services
{
    public interface IChatRoomService
    {
        Task BroadcastMessageAsync(ChatMessage message);
        Task<int> AddUserToChatRoomAsync(User user);
        void ConnectUserToChatRoom(int roomId, Guid userId, IAsyncStreamWriter<ChatMessage> asyncStreamWriter);
        void DisconnectUser(int roomId, Guid userId);
    }
}
