using System;

namespace V8Net.IO.Domain.Core.Events
{
    public abstract class Message
    {
        // Tipo da Mensagem de Evento: Comando, Evento, DomainNotification...
        public string MessageType { get; protected set; }

        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
