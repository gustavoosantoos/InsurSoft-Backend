using InsurSoft.Backend.Web.Api.Models.Input.Segurados;
using InsurSoft.Backend.Web.Segurados.Application.Commands;
using InsurSoft.Backend.Web.Segurados.Application.Interfaces;
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
            var command = CriarSeguradoCommand.Create(input.Nome, input.Sobrenome, input.DataNascimento);

            if (command.IsFailure)
                return BadRequest(command.Errors);

            var result = _seguradoService.CriarSegurado(command.Value);

            if (result.IsFailure)
                return StatusCode(500, result.Errors);

            return Created("", null);
        }
    }
}