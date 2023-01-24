using Chat.Contracts.Contract;
using Chat.Contracts.Domain;
using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service
{
    [ServiceBehavior()]
    public class MessageService : IMessageService
    {
        public void Conect(User user)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<User> GetConnectedUsers()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
