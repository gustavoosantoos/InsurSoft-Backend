using Microsoft.AspNetCore.Mvc;

namespace InsurSoft.Backend.Controllers
{
    [Route("api/web/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Pong";
        }
    }
}

