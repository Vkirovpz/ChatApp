using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.Models
{
    public class Message
    {
        public Message(string author, string text, string room)
        {
            if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException($"'{nameof(author)}' cannot be null or whitespace.", nameof(author));
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException($"'{nameof(text)}' cannot be null or whitespace.", nameof(text));
            if (string.IsNullOrWhiteSpace(room)) throw new ArgumentException($"'{nameof(room)}' cannot be null or whitespace.", nameof(room));

            Author = author;
            Text = text;
            Room = room;
        }

        public string Author { get; }
        public string Text { get; }
        public DateTimeOffset SentOn { get; } = DateTimeOffset.UtcNow;
        public string Room { get; }
    }
}
