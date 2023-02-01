using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Domain.Models
{
    public class ChatApp 
    {
        private readonly List<ChatRoom> _rooms = new List<ChatRoom>();
        private readonly List<User> _users = new List<User>();

        public IEnumerable<ChatRoom> ChatRooms => _rooms.AsReadOnly();
        public IEnumerable<User> Users => _users.AsReadOnly();

 
        public void ConnectUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));

            if (_users.Any(u => u.Username == user.Username))
                throw new InvalidOperationException($"User with that username '{user.Username}', already exist");
                _users.Add(user);
        }

        public ChatRoom CreateChatRoom(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

            if (_rooms.Any(r => r.Name == name)) 
                throw new InvalidOperationException($"Room with name '{name}' already exist.");

            var room = new ChatRoom(name);
            _rooms.Add(room);
            return room;
        }
    }
}