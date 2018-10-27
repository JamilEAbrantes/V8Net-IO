using System;
using V8Net.IO.Domain.Core.Commands;

namespace V8Net.IO.Domain.NoticiasContext.Commands
{
    public abstract class BaseNoticiaCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Titulo { get; protected set; }

        public string Subtitulo { get; protected set; }

        public string Descricao { get; protected set; }

        public string Autor { get; protected set; }

        public DateTime DataCadastro { get; protected set; }
    }
}
