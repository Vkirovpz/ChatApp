using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatServerAppService chatServer;

        public ChatHub(ChatServerAppService chatServer)
        {
            this.chatServer = chatServer;
        }

        public bool ConnectUser(string user)
        {
            var connectedUser = chatServer.ConnectUser(user);
            if (connectedUser.IsConnected == true) 
            {
                return true;
            }
            return false;
        }

        public Task<CreatedRoom> CreateRoom(string username, string roomName)
        {
            var createdRoom = chatServer.CreateChatRoom(roomName, username);
            return Task.FromResult(createdRoom);
        }

        public Task<ConnectedUserToChatRoom> JoinRoom(string user, string roomName)
        {
            var writer = new SignalRMessageWriter(Clients.Caller);
            var connected = chatServer.JoinRoom(roomName, user, writer);
            return Task.FromResult(connected);
        }

        public Task SendMessage(string user, string message)
        {
            chatServer.SendMessage(user, message);
            return Task.CompletedTask;
        }

        public Task LeaveRoom(string user, string roomName)
        {
            chatServer.LeaveRoom(user);
            return Task.CompletedTask;
        }
    }
}
