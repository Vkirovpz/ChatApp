using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ConnectedUserToChatRoom JoinRoom(string roomName, string username, IMessageWriter messageWriter)
        {
            var user = GetUserByUsername(username);
            var room = server.ChatRooms.FirstOrDefault(x => x.Name== roomName);
            user.SetWriter(messageWriter);

            var userJoined = user.JoinRoom(room);
            return userJoined;
        }

        public void SendMessage(string username, string text)
        {
            var user = GetUserByUsername(username);
            user.SendMessage(text);
        }

        public DisconnectedUser LeaveRoom(string username)
        {
            var user = GetUserByUsername(username);
            var room = user.Room;
            return room.DisconnectUser(user);
        }

        public IEnumerable<string> GetAllRooms()
        {
            return server.GetAllChatRoomsNames();
        }

        public User GetUserByUsername(string username)
        {
            return server.GetUserByUsername(username);
        }

        public ChatRoom GetChatRoomByName(string roomName)
        {
            return server.GetChatRoomByName(roomName);
        }


    }
}
