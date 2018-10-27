using System;

namespace V8Net.IO.Application.ViewModel
{
    public class NoticiaViewModel
    {
        public NoticiaViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Subtitulo { get; set; }

        public string Descricao { get; set; }

        public string Autor { get; set; }
    }
}
