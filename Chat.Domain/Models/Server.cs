using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Domain.Models
{
    public class Server
    {
        private readonly IMessageWriter _messageWriter;
        private readonly List<ChatRoom> _rooms = new List<ChatRoom>();
        private readonly List<User> _users = new List<User>();

        public IEnumerable<ChatRoom> ChatRooms => _rooms.AsReadOnly();
        public IEnumerable<User> Users => _users.AsReadOnly();

        public Server(string address, IMessageWriter messageWriter)
        {
            Address = address;
            _messageWriter = messageWriter;
        }

        public string Address { get; }
        public void ConnectUser(string username)
        {
            if (username is null) throw new ArgumentNullException(nameof(username));
            if (_users.Any(u => u.Username == username))
                return;  
             
             var user = CreateUser(username);
             _users.Add(user);
        }

        public void AllChatRooms()
        {
            foreach (var room in ChatRooms)
            {
                _messageWriter.Write(room.Name);
            }

        }

        public User CreateUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));

            return new User(username, _messageWriter);

        }
        public void CreateChatRoom(string name, string username)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));
            if (_rooms.Any(r => r.Name == name))
                return;
                //throw new InvalidOperationException($"Room with name '{name}' already exist.");

            var user = _users.First(u => u.Username == username);
            var room = new ChatRoom(name, _messageWriter);
            _rooms.Add(room);
            room.ConnectUser(user);
        }

        public void InitTestRoomAndUser()
        {
            var room = new ChatRoom("Testroom", _messageWriter);
            var user = new User("Testuser", _messageWriter);
            if (_rooms.Any(r => r.Name == "Testroom"))
                return;
                //throw new InvalidOperationException($"Room with name 'Testroom' already exist.");
            _rooms.Add(room);
            _users.Add(user);
        }

    }
}