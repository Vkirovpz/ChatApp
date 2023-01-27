using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Models
{
    public class User
    {
        public User(string username)
        {
            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }
            this.Username = username;
            Id= Guid.NewGuid();
        }
        public Guid Id { get;}
        public string Username { get;}
    }
}
