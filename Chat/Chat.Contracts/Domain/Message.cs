using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Contracts.Domain
{
    public class Message
    {
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public string Messagesent { get; set; }
    }
}
