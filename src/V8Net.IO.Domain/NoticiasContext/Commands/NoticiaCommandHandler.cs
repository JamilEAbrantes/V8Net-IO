using System;
using System.Linq;
using V8Net.IO.Domain.CommandHandlers;
using V8Net.IO.Domain.Core.Bus;
using V8Net.IO.Domain.Core.Events;
using V8Net.IO.Domain.Core.Notification;
using V8Net.IO.Domain.NoticiasContext.Events;
using V8Net.IO.Domain.NoticiasContext.Repository;

namespace V8Net.IO.Domain.NoticiasContext.Commands
{
    public class NoticiaCommandHandler : CommandHandler,
        IHandler<RegistrarNoticiaCommand>,
        IHandler<AtualizarNoticiaCommand>,
        IHandler<ExcluirNoticiaCommand>
    {
        private readonly INoticiaRepository _noticiaRepository;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public NoticiaCommandHandler(INoticiaRepository noticiaRepository,
                                     IBus bus,
                                     IDomainNotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _noticiaRepository = noticiaRepository;
            _bus = bus;
            _notifications = notifications;
        }

        public void Handle(RegistrarNoticiaCommand message)
        {
            var noticia = Noticia.NoticiaFactory.NovaNoticiaCompleta(message.Id, message.Titulo, message.Subtitulo, message.Descricao, message.Autor);

            var noticiaExistente = _noticiaRepository.Buscar(n => n.Titulo == noticia.Titulo);
            if(noticiaExistente.Any())
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Titulo já existente"));

            if (!NoticiaValido(noticia)) return;

            if (_notifications.HasNotifications()) return;
            _noticiaRepository.Adicionar(noticia);

            _bus.RaiseEvent(new NoticiaRegistradaEvent(message.Id, message.Titulo, message.Subtitulo, message.Descricao, message.Autor));
        }

        public void Handle(AtualizarNoticiaCommand message)
        {
            if (!NoticiaExistente(message.Id, message.MessageType)) return;

            var noticia = _noticiaRepository.ObterPorId(message.Id);
            noticia.AtribuirNoticia(message.Titulo, message.Subtitulo, message.Descricao, message.Autor);

            if (!NoticiaValido(noticia)) return;

            if (_notifications.HasNotifications()) return;
            _noticiaRepository.Atualizar(noticia);

            _bus.RaiseEvent(new NoticiaAtualizadaEvent(message.Id, message.Titulo, message.Subtitulo, message.Descricao, message.Autor));
        }

        public void Handle(ExcluirNoticiaCommand message)
        {
            if (!NoticiaExistente(message.Id, message.MessageType)) return;

            var noticia = _noticiaRepository.ObterPorId(message.Id);

            if (_notifications.HasNotifications()) return;
            _noticiaRepository.Remover(noticia.Id);

            _bus.RaiseEvent(new NoticiaExcluidaEvent(noticia.Id, noticia.Titulo, noticia.Subtitulo, noticia.Descricao, noticia.Autor));
        }

        #region --> Validações

        private bool NoticiaValido(Noticia noticia)
        {
            if (noticia.EhValido()) return true;

            NotificarValidacoesErro(noticia.ValidationResult);
            return false;
        }

        private bool NoticiaExistente(Guid id, string messageType)
        {
            var noticia = _noticiaRepository.ObterPorId(id);

            if (noticia != null)
                return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Noticia não encontrada."));
            return false;
        }

        #endregion
    }
}
