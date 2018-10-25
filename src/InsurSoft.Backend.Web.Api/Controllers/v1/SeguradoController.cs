using InsurSoft.Backend.Web.Segurados.Application.Commands;
using InsurSoft.Backend.Web.Segurados.Application.Interfaces;
using InsurSoft.Backend.Web.Segurados.Input.Segurados;
using InsurSoft.Backend.Shared.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InsurSoft.Backend.Web.Api.Controllers.v1
{
    [Route("api/web/v1/[controller]")]
    [ApiController]
    public class SeguradoController : ApiController
    {
        private readonly ISeguradoAppService _seguradoService;

        public SeguradoController(ISeguradoAppService seguradoAppService)
        {
            _seguradoService = seguradoAppService;
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create(CriarSeguradoInput input)
        {
            var result = _seguradoService.CriarSegurado(input);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Created(nameof(GetById), null);
        }
    }
}