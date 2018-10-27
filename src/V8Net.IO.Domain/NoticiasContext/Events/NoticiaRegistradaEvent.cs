using System;

namespace V8Net.IO.Domain.NoticiasContext.Events
{
    public class NoticiaRegistradaEvent : BaseNoticiaEvent
    {
        public NoticiaRegistradaEvent(
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
