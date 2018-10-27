using System;
using System.Collections.Generic;
using V8Net.IO.Application.ViewModel;

namespace V8Net.IO.Application.Interfaces
{
    public interface INoticiaAppService : IDisposable
    {
        // PS: Nomes de métodos estão em portugues para expressar as intenções do negócio
        void Registrar(NoticiaViewModel obj);

        void Atualizar(NoticiaViewModel obj);

        void Remover(Guid id);

        NoticiaViewModel ObterPorId(Guid id);

        IEnumerable<NoticiaViewModel> ObterTodos();

        IEnumerable<NoticiaViewModel> ObterNoticiaPorAutor(string autor);
    }
}
