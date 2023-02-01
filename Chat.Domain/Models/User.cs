using Chat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Domain
{
    public class User 
    {
        private readonly List<ChatRoom> _chatRooms = new List<ChatRoom>();

        public User(string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException($"'{nameof(username)}' cannot be null or empty.", nameof(username));

            Username = username;
        }

        public IEnumerable<ChatRoom> ChatRooms => _chatRooms.AsReadOnly();
        public string Username { get; }

        public void JoinServer(ChatApp server)
        {
            if (server is null)
                throw new ArgumentNullException(nameof(server));
            server.ConnectUser(this);
        }

        public void JoinChatRoom(ChatRoom chatRoom)
        {
            if (chatRoom is null)
                throw new ArgumentNullException(nameof(chatRoom));

            if (chatRoom.Users.Any(x => x.Username == Username))
                return;
            chatRoom.ConnectUser(this);

            if (_chatRooms.Any(c => c.Name == chatRoom.Name))
                return;
            _chatRooms.Add(chatRoom);
        }

        public void LeaveChatRoom(ChatRoom chatRoom)
        {
            if (chatRoom is null)
                throw new ArgumentNullException(nameof(chatRoom));

            if (!_chatRooms.Any(c => c.Name == chatRoom.Name))
                return;

            chatRoom.DisconnectUser(this);
            _chatRooms.Remove(chatRoom);
        }

    }
}