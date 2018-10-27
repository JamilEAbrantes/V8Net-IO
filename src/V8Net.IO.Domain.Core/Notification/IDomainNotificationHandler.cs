using System.Collections.Generic;
using V8Net.IO.Domain.Core.Events;

namespace V8Net.IO.Domain.Core.Notification
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();

        List<T> GetNotifications();
    }
}
