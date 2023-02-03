using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.Models
{
    public class ChatServerAppService
    {
        private readonly Server server;

        public ChatServerAppService(Server server)
        {
            this.server = server;
        }

        public ConnectedUser ConnectUser(string username)
        {
            return server.ConnectUser(username);
        }

        public CreatedRoom CreateChatRoom(string roomName, string username)
        {
            return server.CreateChatRoom(roomName, username);
        }

        public ConnectedUser JoinRoom (string roomName, string username)
        {
           var user = server.GetUserByUsername(username);
           var room = server.GetChatRoomByName(roomName);

           return user.JoinRoom(room);

        }

        public DisconnectedUser LeaveRoom(string username)
        {
            var user = server.GetUserByUsername(username);
            var room = user.Room;
            return room.DisconnectUser(user);
        }
    }
}
