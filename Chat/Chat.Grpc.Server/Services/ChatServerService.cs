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

        public override Task<JoinChatRoomResponse> JoinChatRoom(JoinChatRoomRequest request, ServerCallContext context)
        {
            var joinedUser = chatServer.JoinRoom(request.RoomName, request.Username);
            return Task.FromResult(new JoinChatRoomResponse
            {
                Success = joinedUser.IsConnected,
                Username = joinedUser.Username,
                Reason = joinedUser.Reason ?? string.Empty

            });
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

        //public override Task<ListRoomsResponse> GetAllChatRooms(GetAllRoomsRequest request, ServerCallContext context)
        //{
        //    var allRooms = chatServer.GetAllRooms();

        //    ListRoomsResponse response = new ListRoomsResponse();
        //    foreach (var room in allRooms) 
        //    {
        //        response.RoomName == room
        //    }
        //     response.RoomName.ToList().AddRange(allRooms);
            

        //}

    }
}