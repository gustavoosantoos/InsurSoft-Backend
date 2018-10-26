using InsurSoft.Backend.Shared.Funcional;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using InsurSoft.Backend.Shared.Notifications.Application;
using InsurSoft.Backend.Shared.Notifications.Domain;
using InsurSoft.Backend.Shared.Web.Extensions;
using InsurSoft.Backend.Shared.Web.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace InsurSoft.Backend.Web.Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        readonly DomainNotificationHandler _domainNotifications;
        readonly ApplicationNotificationHandler _applicationNotifications;
        readonly IMediatorHandler _mediator;

        protected ApiController(
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> domainNotifications,
            INotificationHandler<ApplicationNotification> applicationNotifications)
        {
            _domainNotifications = (DomainNotificationHandler)domainNotifications;
            _applicationNotifications = (ApplicationNotificationHandler)applicationNotifications;
            _mediator = mediator;
        }

        protected IEnumerable<DomainNotification> DomainNotifications => _domainNotifications.GetNotifications();
        protected IEnumerable<ApplicationNotification> ApplicationNotifications => _applicationNotifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!_domainNotifications.HasNotifications()) && (!_applicationNotifications.HasNotifications());
        }

        protected bool HasApplicationErrors()
        {
            return _applicationNotifications.HasNotifications();
        }

        protected bool HasDomainErrors()
        {
            return _domainNotifications.HasNotifications();
        }

        protected new IActionResult Response(object result = null)
        {
            var notificationResponse = NotificationResponseIfExists();

            if (notificationResponse.HasValue)
                return notificationResponse.Value;
            
            return Ok(ApiResponse.Success(result));
        }
        
        public new IActionResult Response<T>(Maybe<T> result)
        {
            var notificationResponse = NotificationResponseIfExists();

            if (notificationResponse.HasValue)
                return notificationResponse.Value;

            if (result.HasNoValue)
                return Ok(ApiResponse.Success(null));

            return Ok(ApiResponse.Success(result.Value));
        }

        protected Maybe<IActionResult> NotificationResponseIfExists()
        {
            if (HasApplicationErrors())
            {
                return InternalServerError(ApiResponse.Error(
                    _applicationNotifications.GetNotifications().Select(n => n.Value)));
            }

            if (HasDomainErrors())
            {
                return BadRequest(ApiResponse.Error(
                    _domainNotifications.GetNotifications().Select(n => n.Value)));
            }

            return null;
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyDomainError(string.Empty, erroMsg);
            }
        }

        protected void NotifyDomainError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

        protected void NotifyApplicationError(string code, string message)
        {
            _mediator.RaiseEvent(new ApplicationNotification(code, message));
        }

        protected ObjectResult InternalServerError(object response)
        {
            return StatusCode(HttpStatusCode.InternalServerError.ToInt(), response);
        }
    }
}