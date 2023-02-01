using System.ServiceModel;


namespace Host
{
    [ServiceContract]
    public interface IChatClient
    {
        [OperationContract(IsOneWay =true)]
        void RecieveMessage(string user, string message);
       
    }
}
