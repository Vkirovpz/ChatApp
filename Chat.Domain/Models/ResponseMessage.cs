using System;
namespace Chat.Domain.Models
{
    public class ResponseMessage
    {
        public string Author { get; set;}
        public string Text { get; set; }
        public DateTimeOffset SentOn { get; set; } = DateTimeOffset.UtcNow;
        public string Room { get; set; }
    }
}
