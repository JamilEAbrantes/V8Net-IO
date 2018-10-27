using System;

namespace V8Net.IO.Domain.NoticiasContext.Commands
{
    public class AtualizarNoticiaCommand : BaseNoticiaCommand
    {
        public AtualizarNoticiaCommand(
            Guid id,
            string titulo,
            string subtitulo,
            string descricao,
            string autor)
        {
            Id = id;
            Titulo = titulo;
            Subtitulo = subtitulo;
            Descricao = descricao;
            Autor = autor;
        }
    }
}
