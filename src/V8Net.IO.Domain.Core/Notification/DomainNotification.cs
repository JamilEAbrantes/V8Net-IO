﻿using System;
using V8Net.IO.Domain.Core.Events;

namespace V8Net.IO.Domain.Core.Notification
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }
    }
}
