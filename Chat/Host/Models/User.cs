using System;

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
