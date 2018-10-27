using V8Net.IO.Domain.Core.Commands;
using V8Net.IO.Domain.Core.Events;

namespace V8Net.IO.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
