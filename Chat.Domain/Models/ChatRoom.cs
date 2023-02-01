using System;
using System.Collections.Generic;
using System.Reflection;

namespace Chat.Domain.Models
{
    public class ChatRoom 
    {
        private readonly List<User> _users = new List<User>();

        public ChatRoom(string name)
        {
            Name = name;
        }

        public IEnumerable<User> Users => _users.AsReadOnly();

        public string Name { get; }

        public void ConnectUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            _users.Add(user);
        }

        public void DisconnectUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            _users.Remove(user);
        }

    }

}
