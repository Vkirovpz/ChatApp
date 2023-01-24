using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode= InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        Dictionary<IChatClient, string> _users = new Dictionary<IChatClient, string>();
        public void Join(string username)
        {
            var conection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            _users[conection] = username;
        }

        public void SendMessage(string message)
        {
            var conection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            string user;
            if (!_users.TryGetValue(conection, out user))
                return;
            foreach (var other in _users.Keys)
            {
                if (other == conection)
                    continue;
                other.RecieveMessage(user, message);
            }
        }
    }
}
