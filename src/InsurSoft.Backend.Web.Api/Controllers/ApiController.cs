using InsurSoft.Backend.Shared.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InsurSoft.Backend.Web.Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        public ObjectResult InternalServerError(object response)
        {
            return StatusCode(HttpStatusCode.InternalServerError.ToInt(), response);
        }
    }
}