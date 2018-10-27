using FluentValidation;
using System;
using V8Net.IO.Domain.Core.Models;

namespace V8Net.IO.Domain.NoticiasContext
{
    public class Noticia : Entity<Noticia>
    {
        private Noticia() { }

        public Noticia(
            string titulo, 
            string subtitulo, 
            string descricao,
            string autor)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Subtitulo = subtitulo;
            Descricao = descricao;
            Autor = autor;
            DataCadastro = DateTime.Now;
        }

        public string Titulo { get; private set; }

        public string Subtitulo { get; private  set; }

        public string Descricao { get; private  set; }

        public string Autor { get; private  set; }

        public DateTime DataCadastro { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        public void AtribuirNoticia(string titulo, string subtitulo, string descricao, string autor)
        {
            this.Titulo = titulo;
            this.Subtitulo = subtitulo;
            this.Descricao = descricao;
            this.Autor = autor;
        }

        #region --> Validações

        private void Validar()
        {
            ValidarTitulo();
            ValidarSubtitulo();
            ValidarDescricao();
            ValidarAutor();
            ValidationResult = Validate(this);
        }

        private void ValidarTitulo()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("O título deve ser fornecido.")
                .Length(2, 30).WithMessage("O título precisa ter entre 2 e 30 caracteres.");
        }

        private void ValidarSubtitulo()
        {
            RuleFor(c => c.Subtitulo)
                .NotEmpty().WithMessage("O subtítulo deve ser fornecido.")
                .Length(2, 100).WithMessage("O subtítulo precisa ter entre 2 e 100 caracteres.");
        }

        private void ValidarDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O descrição deve ser fornecida.")
                .Length(2, 500).WithMessage("O descrição precisa ter entre 2 e 500 caracteres.");
        }

        private void ValidarAutor()
        {
            RuleFor(c => c.Autor)
                .NotEmpty().WithMessage("O autor deve ser fornecido.")
                .Length(2, 20).WithMessage("O autor precisa ter entre 2 e 20 caracteres.");
        }

        #endregion

        public static class NoticiaFactory
        {
            public static Noticia NovaNoticiaCompleta(Guid id, string titulo, string subtitulo, string descricao, string autor)
            {
                var noticia = new Noticia()
                {
                    Id = id,
                    Titulo = titulo,
                    Subtitulo = subtitulo,
                    Descricao = descricao,
                    Autor = autor,
                    DataCadastro = DateTime.Now
                };

                return noticia;
            }
        }
    }
}
