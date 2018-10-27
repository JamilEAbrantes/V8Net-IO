using System;
using V8Net.IO.Domain.Core.Events;

namespace V8Net.IO.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime TimeStamp { get; set; } // Verifica quando o comando foi disparado

        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
