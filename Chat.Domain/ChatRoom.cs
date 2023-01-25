using System;
using System.Collections.Generic;

namespace Chat.Domain
{
    public class ChatRoom : IEquatable<ChatRoom>
    {
        private List<User> users = new List<User>();

        public ChatRoom(string roomName)
        {
            this.RoomName = roomName;
        }

        public IEnumerable<User> Users => users.AsReadOnly();

        public string RoomName { get; }

        public void ConnectUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            users.Add(user);     
        }

        public void DisconnectUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            users.Remove(user);
        }

        public bool Equals(ChatRoom other)
        {
            if (other is null) return false;

            return other.RoomName == RoomName;
        }
   
    }
}