using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Domain.Models
{
    public class ChatRoom
    {
        private readonly IMessageWriter _messageWriter;
        private readonly List<User> _usersInRoom = new List<User>();
        private readonly List<Message> _messages = new List<Message>();

        public ChatRoom(string name, IMessageWriter messageWriter)
        {
            Name = name;
            _messageWriter = messageWriter;
        }

        public IEnumerable<User> Users => _usersInRoom.AsReadOnly();

        public string Name { get; }

        public void ConnectUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            if (_usersInRoom.Any(u => u.Username == user.Username))
                return;
                //throw new InvalidOperationException($"User with that username '{user.Username}', already exist");
            _usersInRoom.Add(user);
            user.JoinRoom(this);
            _messageWriter.Write($"User {user.Username} joined {Name}");

            foreach (var msg in _messages)
            {
                user.ReceiveMessage(msg);
            }
        }

        public void DisconnectUser(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            _usersInRoom.Remove(user);
        }

        public void ReceiveMessageFromUser(string text, string username)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException($"'{nameof(text)}' cannot be null or empty.", nameof(text));
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException($"'{nameof(username)}' cannot be null or empty.", nameof(username));
            if (_usersInRoom.Any(u => u.Username == username) == false)
                return;
            var message = new Message(username, text, Name);
            _messages.Add(message);
            PublishMessage(message);
        }

        public void PublishMessage(Message message)
        {
            if (message is null) throw new ArgumentNullException(nameof(message));

            foreach (var user in _usersInRoom.Where(u => u.Username != message.Author))
            {
                user.ReceiveMessage(message);
            }
        }
    }
}
