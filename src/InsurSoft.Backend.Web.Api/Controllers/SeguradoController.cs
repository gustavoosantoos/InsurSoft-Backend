using InsurSoft.Backend.Web.Segurados.Application.Commands;
using InsurSoft.Backend.Web.Segurados.Application.Interfaces;
using InsurSoft.Backend.Web.Segurados.Input.Segurados;
using InsurSoft.Backend.Shared.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InsurSoft.Backend.Web.Api.Controllers
{
    [Route("api/web/[controller]")]
    [ApiController]
    public class SeguradoController : ControllerBase
    {
        private readonly ISeguradoAppService _seguradoService;

        public SeguradoController(ISeguradoAppService seguradoAppService)
        {
            _seguradoService = seguradoAppService;
        }

        [HttpPost]
        public IActionResult Create(CriarSeguradoInput input)
        {
            var command = CriarSeguradoCommand.Create(input);

            if (command.IsFailure)
                return BadRequest(command.Errors);

            var result = _seguradoService.CriarSegurado(command.Value);

            if (result.IsFailure)
                return StatusCode(HttpStatusCode.InternalServerError.ToInt(), result.Errors);

            return Created("", null);
        }
    }
}