using GrpcStreaming.Models;

namespace GrpcStreaming.Providers
{
    public interface IChatRoomProvider
    {
        ChatRoom GetFreeChatRoom();
        ChatRoom GetChatRoomById(int roomId);
        ChatRoom AddChatRoom();
    }
}
