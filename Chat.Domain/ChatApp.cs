using System.Collections.Generic;
using System.Linq;

namespace Chat.Domain
{
    public class ChatApp
    {
        private List<ChatRoom> rooms = new List<ChatRoom>();    
        private List<User> users = new List<User>();

        public IEnumerable<ChatRoom> ChatRooms => rooms.AsReadOnly();
        public IEnumerable<User> Users => users.AsReadOnly();

        public ChatRoom CreateChatRoom(string roomName)
        { 
            //var others = rooms.Where(r => r.RoomName == roomName);
            //if (others.Any())

            var room = new ChatRoom(roomName);
            rooms.Add(room);
            return room;
        }

        public User CreateUser(string userName)
        {
            var user = new User(userName);
            users.Add(user);
            return user;
        }
    }
}