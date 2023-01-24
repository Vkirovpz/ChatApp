using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Contracts.Domain
{
    public class User
    {
        public string UserName { get; set; }
        public IObservable<Message> UserMessages { get; set; }
    }
}
