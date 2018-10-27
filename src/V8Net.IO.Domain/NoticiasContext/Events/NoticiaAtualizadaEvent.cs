using System;

namespace V8Net.IO.Domain.NoticiasContext.Events
{
    public class NoticiaAtualizadaEvent : BaseNoticiaEvent
    {
        public NoticiaAtualizadaEvent(
            Guid id,
            string titulo,
            string subtitulo,
            string descricao,
            string autor)
        {
            Id = id;
            Titulo = titulo;
            Subtitulo = subtitulo;
            Descrição = descricao;
            Autor = autor;

            AggregateId = id;
        }
    }
}
