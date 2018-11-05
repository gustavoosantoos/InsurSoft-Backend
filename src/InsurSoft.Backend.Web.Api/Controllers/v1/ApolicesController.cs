using InsurSoft.Backend.Shared.Application.Interfaces;
using InsurSoft.Backend.Shared.Application.Notifications.Application;
using InsurSoft.Backend.Shared.Application.Notifications.Domain;
using InsurSoft.Backend.Shared.Web.Responses;
using InsurSoft.Backend.Web.Seguros.Application.CriarApolice;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Api.Controllers.v1
{
    [ApiController]
    [Route("api/web/v1/[controller]")]
    public class ApolicesController : ApiController
    {
        public ApolicesController(
            IMediator mediator, 
            IMediatorHandler mediatorHandler, 
            INotificationHandler<DomainNotification> domainNotifications, 
            INotificationHandler<ApplicationNotification> applicationNotifications) 
            : base(mediator, mediatorHandler, domainNotifications, applicationNotifications)
        {
            
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiDataResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Create([FromBody] CriarApoliceCommand command)
        {
            NotifyModelStateErrors();

            if (!ModelState.IsValid)
                return Response();

            return Response(await Mediator.Send(command));
        }
    }
}
