using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Domain
{
    public class User
    {
        private List<ChatRoom> chatRooms = new List<ChatRoom>();

        public User(string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException($"'{nameof(username)}' cannot be null or empty.", nameof(username));

            Username = username;
        }

        public IEnumerable<ChatRoom> ChatRooms => chatRooms.AsReadOnly();
        public string Username { get; }

        public void Join(ChatRoom chatRoom)
        {
            if (chatRoom.Users.Contains(this))
                return;           
            chatRoom.ConnectUser(this);
            chatRooms.Add(chatRoom);
        }

        public void Leave(ChatRoom chatRoom)
        {
            if (!chatRooms.Contains(chatRoom))
                return;

            chatRoom.DisconnectUser(this);
            chatRooms.Remove(chatRoom);
        }

    }
}