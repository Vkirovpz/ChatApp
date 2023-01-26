using System;
using System.Collections.Generic;
using System.Reflection;

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

        public override string ToString() => RoomName;

        public override bool Equals(object obj) => Equals(obj as ChatRoom);

        public override int GetHashCode() => RoomName.GetHashCode();

        public bool Equals(ChatRoom other)
        {
            if (other is null) return false;

            return other.RoomName == RoomName;
        }
        public static bool operator ==(ChatRoom obj1, ChatRoom obj2) => obj1.Equals(obj2);
        public static bool operator !=(ChatRoom obj1, ChatRoom obj2) => obj1 == obj2 == false;
    }

}
