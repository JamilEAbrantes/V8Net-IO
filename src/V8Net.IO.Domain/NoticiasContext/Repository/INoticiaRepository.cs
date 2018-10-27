using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace V8Net.IO.Domain.NoticiasContext.Repository
{
    public interface INoticiaRepository
    {
        void Adicionar(Noticia obj);

        void Atualizar(Noticia obj);

        void Remover(Guid id);

        Noticia ObterPorId(Guid id);

        IEnumerable<Noticia> ObterTodos();

        IEnumerable<Noticia> Buscar(Expression<Func<Noticia, bool>> predicate);

        IEnumerable<Noticia> ObterNoticiaPorAutor(string autor);

        #region --> Log's

        void AdicionarLog(Guid id, string titulo, string subtitulo, string descricao, string autor, DateTime dataOperacao, char operacao);

        #endregion
    }
}