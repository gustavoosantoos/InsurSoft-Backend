using InsurSoft.Backend.Shared.Interfaces.Domain;
using InsurSoft.Backend.Shared.Notifications.Application;
using InsurSoft.Backend.Shared.Notifications.Domain;
using InsurSoft.Backend.Shared.Web.Responses;
using InsurSoft.Backend.Web.Segurados.Application.AdicionarSegurado;
using InsurSoft.Backend.Web.Segurados.Application.ListarSegurados;
using InsurSoft.Backend.Web.Segurados.Application.ObterSeguradoDetalhado;
using InsurSoft.Backend.Web.Segurados.Application.RemoverSegurado;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Api.Controllers.v1
{
    [Route("api/web/v1/[controller]")]
    [ApiController]
    public class SeguradoController : ApiController
    {
        public SeguradoController(
            IMediator mediator,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> domainNotifications,
            INotificationHandler<ApplicationNotification> applicationNotifications)
            : base(mediator, mediatorHandler, domainNotifications, applicationNotifications)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiDataResponse<List<SeguradoPreviewViewModel>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Response(await Mediator.Send(new ListarSeguradosQuery()));
        }

        [HttpGet]
        [Route("{codigo:int}")]
        [ProducesResponseType(typeof(ApiDataResponse<SeguradoDetalhadoViewModel>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> GetById([FromRoute] ObterSeguradoDetalhadoQuery query)
        {
            return Response(await Mediator.Send(query));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiDataResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Create([FromBody] AdicionarSeguradoCommand command)
        {
            return Response(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{codigo:int}")]
        [ProducesResponseType(typeof(ApiDataResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        public async Task<IActionResult> Delete([FromRoute] RemoverSeguradoCommand command)
        {
            return Response(await Mediator.Send(command));
        }
    }
}