using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using V8Net.IO.Domain.NoticiasContext;
using V8Net.IO.Domain.NoticiasContext.Repository;
using V8Net.IO.Infra.Data.Context;

namespace V8Net.IO.Infra.Data.Repository
{
    public class NoticiaRepository : INoticiaRepository
    {
        private readonly V8NetContext _context;

        public NoticiaRepository(V8NetContext context)
        {
            _context = context;
        }

        public void Adicionar(Noticia obj)
        {
            var query = $"INSERT INTO Noticias (Id, Titulo, Subtitulo, Descricao, Autor, DataCadastro)  VALUES  (@Id, @Titulo, @Subtitulo, @Descricao, @Autor, @DataCadastro)";

            var param = new DynamicParameters();
            param.Add(name: "Id", value: obj.Id, direction: ParameterDirection.Input);
            param.Add(name: "Titulo", value: obj.Titulo, direction: ParameterDirection.Input);
            param.Add(name: "Subtitulo", value: obj.Subtitulo, direction: ParameterDirection.Input);
            param.Add(name: "Descricao", value: obj.Descricao, direction: ParameterDirection.Input);
            param.Add(name: "Autor", value: obj.Autor, direction: ParameterDirection.Input);
            param.Add(name: "DataCadastro", value: obj.DataCadastro, direction: ParameterDirection.Input);

            _context.Connection.Execute(query.ToString(), param);
        }

        public void Atualizar(Noticia obj)
        {
            var query = $"UPDATE Noticias SET Titulo = @Titulo, Subtitulo = @Subtitulo, Descricao = @Descricao, Autor = @Autor WHERE Id = @Id";

            var param = new DynamicParameters();
            param.Add(name: "Id", value: obj.Id, direction: ParameterDirection.Input);
            param.Add(name: "Titulo", value: obj.Titulo, direction: ParameterDirection.Input);
            param.Add(name: "Subtitulo", value: obj.Subtitulo, direction: ParameterDirection.Input);
            param.Add(name: "Descricao", value: obj.Descricao, direction: ParameterDirection.Input);
            param.Add(name: "Autor", value: obj.Autor, direction: ParameterDirection.Input);

            _context.Connection.Execute(query.ToString(), param);
        }

        public void Remover(Guid id)
        {
            var query = $"DELETE FROM Noticias WHERE Id = @Id";

            var param = new DynamicParameters();
            param.Add(name: "Id", value: id, direction: ParameterDirection.Input);

            _context.Connection.Execute(query, param);
        }

        public Noticia ObterPorId(Guid id)
        {
            var query = $"SELECT n.Id, n.Titulo, n.Subtitulo, n.Descricao, n.Autor, n.DataCadastro FROM Noticias n WHERE n.Id = @Id";

            var noticia = _context.Connection.Query<Noticia>(query.ToString(), new { Id = id }).FirstOrDefault();

            return noticia;
        }

        public IEnumerable<Noticia> ObterTodos()
        {
            var query = $"SELECT n.Id, n.Titulo, n.Subtitulo, n.Descricao, n.Autor, n.DataCadastro FROM Noticias n ORDER BY n.Autor ASC";

            var noticias = _context.Connection.Query<Noticia>(query.ToString(), new { });

            return noticias;
        }

        public IEnumerable<Noticia> Buscar(Expression<Func<Noticia, bool>> predicate)
        {
            var noticias = ObterTodos().Where(predicate.Compile());
            if (noticias == null)
                return null;
            
            return noticias;
        }

        public IEnumerable<Noticia> ObterNoticiaPorAutor(string autor)
        {
            var query = $"SELECT n.Id, n.Titulo, n.Subtitulo, n.Descricao, n.Autor, n.DataCadastro FROM Noticias n WHERE n.Autor LIKE '%{ autor }%' ORDER BY n.Titulo DESC";

            var noticias = _context.Connection.Query<Noticia>(query.ToString(), new { });

            return noticias;
        }

        public void AdicionarLog(Guid id, string titulo, string subtitulo, string descricao, string autor, DateTime dataOperacao, char operacao)
        {
            var query = $"INSERT INTO Noticias_LOG (Id, Titulo, Subtitulo, Descricao, Autor, DataOperacao, Operacao)  VALUES  (@Id, @Titulo, @Subtitulo, @Descricao, @Autor, @DataOperacao, @Operacao)";

            var param = new DynamicParameters();
            param.Add(name: "Id", value: id, direction: ParameterDirection.Input);
            param.Add(name: "Titulo", value: titulo, direction: ParameterDirection.Input);
            param.Add(name: "Subtitulo", value: subtitulo, direction: ParameterDirection.Input);
            param.Add(name: "Descricao", value: descricao, direction: ParameterDirection.Input);
            param.Add(name: "Autor", value: autor, direction: ParameterDirection.Input);
            param.Add(name: "DataOperacao", value: dataOperacao, direction: ParameterDirection.Input);
            param.Add(name: "Operacao", value: operacao, direction: ParameterDirection.Input);

            _context.Connection.Execute(query.ToString(), param);
        }
    }
}
