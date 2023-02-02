using Chat.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chat.Domain
{
    public class TextWriterMessageWriter : IMessageWriter, IDisposable
    {
        private readonly TextWriter textWriter;

        public TextWriterMessageWriter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public void Dispose()
        {
            textWriter?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Write(string message)
        {
            textWriter.WriteLine($"{message}");
        }

        public void WriteMessage(Message message)
        {
            textWriter.WriteLine($"{message.Author} : {message.Text}  {message.SentOn}");
        }
    }
}
