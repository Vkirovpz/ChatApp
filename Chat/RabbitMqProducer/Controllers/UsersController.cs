using Chat.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMqProducer.RabbitMQ;

namespace RabbitMqProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRabbitMQProducer _rabbitMQProducer;
        private readonly ChatServerAppService _chatServer;

        public UsersController(IRabbitMQProducer rabbitMQProducer, ChatServerAppService chatService)
        {
            _rabbitMQProducer = rabbitMQProducer;
            _chatServer = chatService;
        }

        [HttpPost("/connectUser")]
        public ConnectedUser ConnectUser([FromBody] string username)
        {
            var connectedUser = _chatServer.ConnectUser(username);
            return connectedUser;
        }

        [HttpPost("/leaveRoom")]
        public DisconnectedUser LeaveRoom(string username)
        {
            var disconnectedUser = _chatServer.LeaveRoom(username);
            return disconnectedUser;
        }

        [HttpPost("/createRoom")]
        public CreatedRoom CreateChatRoom(string username, string roomName)
        {
            var createdRoom = _chatServer.CreateChatRoom(roomName, username);
            return createdRoom;
        }

        [HttpPost("/sendMessage")]
        public void SendMessage(string username, string message)
        {
            _chatServer.SendMessage(username, message);
        }

        [HttpGet("/getAllRooms")]
        public IEnumerable<string> GetAllRooms()
        {
            var allRooms = _chatServer.GetAllRooms();
            return allRooms;
        }

        [HttpPost("/joinRoom")]
        public ConnectedUserToChatRoom JoinChatRoom(string username, string roomName)
        {
            var writer = new RabbitMQMessageWriter(_rabbitMQProducer);
            var connectedUser = _chatServer.JoinRoom(roomName, username, writer);
            return connectedUser;
        }
    }
}
