using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    internal class ServerUser
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public OperationContext operationContext { get; set; }
    }
}
