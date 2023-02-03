using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Domain.Models
{
    public class ChatRoom
    {
        private readonly List<User> _usersInRoom = new List<User>();
        private readonly List<Message> _messages = new List<Message>();

        public ChatRoom(string name)
        {
            Name = name;
        }

        public IEnumerable<User> Users => _usersInRoom.AsReadOnly();

        public string Name { get; }

        public bool ConnectUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            if (_usersInRoom.Any(u => u.Username == user.Username))
                return false;
            //throw new InvalidOperationException($"User with that username '{user.Username}', already exist");
            _usersInRoom.Add(user);
            return true;
        }

        public DisconnectedUser DisconnectUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            _usersInRoom.Remove(user);
            return new DisconnectedUser(true, user.Username);
  
        }

        public IEnumerable<Message> GetAllMessages() => _messages.ToList();

        public void PublishMessage(Message message)
        {
            if (message is null) throw new ArgumentNullException(nameof(message));
            if (_usersInRoom.Any(u => u.Username == message.Author) == false)
                throw new InvalidOperationException($"Cannot publish message. Message author '{message.Author}' is not in chat room '{Name}'.");

            _messages.Add(message);

            foreach (var user in _usersInRoom.Where(u => u.Username != message.Author))
            {
                user.ReceiveMessage(message);
            }
        }
    }
}
