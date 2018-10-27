using System;
using V8Net.IO.Domain.Core.Events;
using V8Net.IO.Domain.NoticiasContext.Repository;

namespace V8Net.IO.Domain.NoticiasContext.Events
{
    public class NoticiaEventHandler :
        IHandler<NoticiaRegistradaEvent>,
        IHandler<NoticiaAtualizadaEvent>,
        IHandler<NoticiaExcluidaEvent>
    {
        private readonly INoticiaRepository _noticiaRepository;

        public NoticiaEventHandler(INoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }

        public void Handle(NoticiaRegistradaEvent message)
        {
            // FAÇA AQUI: Enviar e-mail, Log de auditoria, Notificações
            _noticiaRepository.AdicionarLog(message.AggregateId, message.Titulo, message.Subtitulo, message.Descrição, message.Autor, message.TimeStamp , 'I');
        }

        public void Handle(NoticiaAtualizadaEvent message)
        {
            // FAÇA AQUI: Enviar e-mail, Log de auditoria, Notificações
            _noticiaRepository.AdicionarLog(message.AggregateId, message.Titulo, message.Subtitulo, message.Descrição, message.Autor, message.TimeStamp, 'A');
        }

        public void Handle(NoticiaExcluidaEvent message)
        {
            // FAÇA AQUI: Enviar e-mail, Log de auditoria, Notificações
            _noticiaRepository.AdicionarLog(message.AggregateId, message.Titulo, message.Subtitulo, message.Descrição, message.Autor, message.TimeStamp, 'E');
        }
    }
}
