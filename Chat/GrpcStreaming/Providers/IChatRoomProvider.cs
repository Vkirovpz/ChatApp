using GrpcStreaming.Models;

namespace GrpcStreaming.Providers
{
    public interface IChatRoomProvider
    {
        ChatRoom GetRandomChatRoom();
        ChatRoom GetChatRoomById(int roomId);
        ChatRoom AddChatRoom();
    }
}
