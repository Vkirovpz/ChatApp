using Chat.Contracts.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Contracts.Contract
{
    public interface IMessageServiceCallBack
    {
        [OperationContract(IsOneWay = true)]
        void ForwardToClient(Message message);

        [OperationContract(IsOneWay =true)]
        void UserConnected(ObservableCollection<User> users);
    }
}
