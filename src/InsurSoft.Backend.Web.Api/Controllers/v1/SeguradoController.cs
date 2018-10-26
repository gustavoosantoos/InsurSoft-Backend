using InsurSoft.Backend.Web.Segurados.Application.Commands;
using InsurSoft.Backend.Web.Segurados.Application.Interfaces;
using InsurSoft.Backend.Web.Segurados.Input.Segurados;
using InsurSoft.Backend.Shared.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using InsurSoft.Backend.Shared.Interfaces.Domain;
using MediatR;
using InsurSoft.Backend.Shared.Notifications.Domain;
using InsurSoft.Backend.Shared.Notifications.Application;
using System.Threading.Tasks;

namespace InsurSoft.Backend.Web.Api.Controllers.v1
{
    [Route("api/web/v1/[controller]")]
    [ApiController]
    public class SeguradoController : ApiController
    {
        private readonly ISeguradoAppService _seguradoService;

        public SeguradoController(
            ISeguradoAppService seguradoAppService,
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> domainNotifications,
            INotificationHandler<ApplicationNotification> applicationNotifications)
            : base(mediatorHandler, domainNotifications, applicationNotifications)
        {
            _seguradoService = seguradoAppService;
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            return Response(await _seguradoService.ObterPorCodigo(id));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create(CriarSeguradoInput input)
        {
            await _seguradoService.CriarSegurado(input);
            
            return Response();
        }
    }
}