using Chat.Domain.Models;
using System;
using System.IO;
using System.Threading.Tasks;

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

        public async Task WriteMessageAsync(Message message)
        {
            await textWriter.WriteLineAsync($"{message.Author} : {message.Text}");
        }
    }
}
