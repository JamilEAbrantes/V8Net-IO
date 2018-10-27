using System;
using V8Net.IO.Domain.Core.Events;

namespace V8Net.IO.Domain.NoticiasContext.Events
{
    public abstract class BaseNoticiaEvent : Event
    {
        public Guid Id { get; protected set; }

        public string Titulo { get; protected set; }

        public string Subtitulo { get; protected set; }

        public string Descrição { get; protected set; }

        public string Autor { get; protected set; }

        public DateTime DataCadastro { get; protected set; }
    }
}
