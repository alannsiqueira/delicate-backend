using System.Collections.Generic;
using System.Linq;
using Delicate.Application.Response;
using Delicate.Domain.Core.Bus;
using Delicate.Domain.Core.Enums;
using Delicate.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delicate.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected ApiController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected new IActionResult Response<TViewModel>(TViewModel viewModel)
        {

            var notifications =
                Notifications.Select(notification => new Notification(string.Empty, notification.Value));

            var response = new Response<dynamic>(notifications, ESeverity.Error, null);
            if (!IsValidOperation()) return BadRequest(response);

            response.Data = viewModel;
            response.Severity = ESeverity.Success;
            return Ok(response);

        }

        protected new IActionResult Response()
        {
            return Response<dynamic>(null);
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

    }
}