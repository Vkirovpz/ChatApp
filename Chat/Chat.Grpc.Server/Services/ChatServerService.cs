using Chat.Domain.Models;
using Chat.Grpc.Server.Protos;
using Grpc.Core;

namespace Chat.Grpc.Server.Services
{
    public class ChatServerService : ChatServer.ChatServerBase
    {
        private readonly ChatServerAppService chatServer;

        public ChatServerService(ChatServerAppService chatServer)
        {
            this.chatServer = chatServer;
        }

        public override Task<ConnectUserResponse> ConnectUser(ConnectUserRequest request, ServerCallContext context)
        {
            var connectedUser = chatServer.ConnectUser(request.Username);
            return Task.FromResult(new ConnectUserResponse
            {
                Success = connectedUser.IsConnected,
                Reason = connectedUser.Reason ?? string.Empty
            });
        }

        public override Task<CreateChatRoomResponse> CreateChatRoom(CreateChatRoomRequest request, ServerCallContext context)
        {
            var createdRoom = chatServer.CreateChatRoom(request.RoomName, request.Username);
            return Task.FromResult(new CreateChatRoomResponse
            {
                Success = createdRoom.IsCreated,
                RoomName = createdRoom.RoomName,
                Reason = createdRoom.Reason ?? string.Empty
            });
        }

        public override Task JoinChatRoom(JoinChatRoomRequest request, IServerStreamWriter<ChatMessage> responseStream, ServerCallContext context)
        {
            var writer = new GrpcTextWriter(responseStream);
            var joinedUser = chatServer.JoinRoom(request.RoomName, request.Username, writer);
            while (context.CancellationToken.IsCancellationRequested == false)
            {
            }

            return Task.CompletedTask;
        }

        public override Task<LeaveChatRoomResponse> LeaveChatRoom(LeaveChatRoomRequest request, ServerCallContext context)
        {
            var disconnectedUser = chatServer.LeaveRoom(request.Username);
            return Task.FromResult(new LeaveChatRoomResponse
            {
                Username = disconnectedUser.Username,
                Success = disconnectedUser.IsDisconnected
            });
        }

        public override Task<Empty> SendMessage(ChatMessage request, ServerCallContext context)
        {
            if (string.Equals(request.Text, "!leave", StringComparison.OrdinalIgnoreCase))
                return Task.FromResult(new Empty
                {
                    Result = "leave"
                });

            chatServer.SendMessage(request.Author, request.Text);

            return Task.FromResult(new Empty());
        }

        public override Task<ListRoomsResponse> GetAllChatRooms(GetAllRoomsRequest request, ServerCallContext context)
        {
            var rooms = chatServer.GetAllRooms().ToList();
            ListRoomsResponse response = new ListRoomsResponse();
            response.RoomName.AddRange(rooms);

            return Task.FromResult(response);
        }
    }
}