using Chat.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using RabbitMQ.Client;
using RabbitMqProducer.RabbitMQ;
using System.Threading.Channels;

namespace RabbitMqProducer.Service
{

    public class ChatService 
    {
        private readonly IRabbitMQProducer _rabbitMQProducer;
        private readonly ChatServerAppService _chatServer;

        public ChatService(IRabbitMQProducer rabbitMQProducer, ChatServerAppService chatServer)
        {
            _rabbitMQProducer = rabbitMQProducer;
            _chatServer = chatServer;
        }

        public ConnectedUser ConnectUser(string username)
        {
            var connectedUser = _chatServer.ConnectUser(username);
            _rabbitMQProducer.SendMessage(connectedUser.IsConnected);
            return connectedUser;
        }

        public DisconnectedUser LeaveRoom(string username)
        {
            var disconnectedUser = _chatServer.LeaveRoom(username);
            return disconnectedUser;
        }

        public CreatedRoom CreateChatRoom(string username, string romName)
        {
            var createdRoom = _chatServer.CreateChatRoom(romName, username);
            return createdRoom;
        }

        public void SendMessage(string username, string message)
        {
            _chatServer.SendMessage(username, message);

        }

        public IEnumerable<string> GetAllRooms()
        {
            var allRooms = _chatServer.GetAllRooms();
            return allRooms;
        }

        //[HttpGet("joinroom")]
        //public ConnectedUserToChatRoom JoinChatRoom(string username, string roomName)
        //{
        //    var writer = new RabbitMQMessageWriter();
        //    var connectedUser = _chatServer.JoinRoom(roomName, username, writer);
        //    return connectedUser;
        //}

    }
}
