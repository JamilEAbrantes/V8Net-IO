using FluentValidation.Results;
using System;
using V8Net.IO.Domain.Core.Bus;
using V8Net.IO.Domain.Core.Notification;

namespace V8Net.IO.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        protected CommandHandler(IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _bus = bus;
            _notifications = notifications;
        }

        protected void NotificarValidacoesErro(ValidationResult validatioResult)
        {
            foreach (var error in validatioResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }
    }
}