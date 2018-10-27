using System;

namespace V8Net.IO.Domain.Core.Events
{
    public abstract class Event : Message
    {
        public DateTime TimeStamp { get; private set; }

        public Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
