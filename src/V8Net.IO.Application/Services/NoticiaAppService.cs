using AutoMapper;
using System;
using System.Collections.Generic;
using V8Net.IO.Application.Interfaces;
using V8Net.IO.Application.ViewModel;
using V8Net.IO.Domain.Core.Bus;
using V8Net.IO.Domain.NoticiasContext.Commands;
using V8Net.IO.Domain.NoticiasContext.Repository;

namespace V8Net.IO.Application.Services
{
    public class NoticiaAppService : INoticiaAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly INoticiaRepository _noticiaRepository;

        public NoticiaAppService(IBus bus, IMapper mapper, INoticiaRepository noticiaRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _noticiaRepository = noticiaRepository;
        }

        public void Registrar(NoticiaViewModel noticiaViewModel)
        {
            var noticiaCommand = _mapper.Map<RegistrarNoticiaCommand>(noticiaViewModel);
            _bus.SendCommand(noticiaCommand);
        }

        public void Atualizar(NoticiaViewModel noticiaViewModel)
        {
            var noticiaCommand = _mapper.Map<AtualizarNoticiaCommand>(noticiaViewModel);
            _bus.SendCommand(noticiaCommand);
        }

        public void Remover(Guid id)
        {
            _bus.SendCommand(new ExcluirNoticiaCommand(id)); 
        }

        public NoticiaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<NoticiaViewModel>(_noticiaRepository.ObterPorId(id));
        }

        public IEnumerable<NoticiaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<NoticiaViewModel>>(_noticiaRepository.ObterTodos());
        }

        public IEnumerable<NoticiaViewModel> ObterNoticiaPorAutor(string autor)
        {
            return _mapper.Map<IEnumerable<NoticiaViewModel>>(_noticiaRepository.ObterNoticiaPorAutor(autor));
        }

        public void Dispose()
        {
            //TODO: FALTA IMPLEMENTAR
        }
    }
}
