using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using V8Net.IO.Domain.Core.Bus;
using V8Net.IO.Domain.Core.Notification;

namespace V8Net.IO.Services.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IBus _bus;

        protected ApiController(IDomainNotificationHandler<DomainNotification> notifications,
                                IBus mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _bus = mediator;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _bus.RaiseEvent(new DomainNotification(code, message));
        }
    }
}