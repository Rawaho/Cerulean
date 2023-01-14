using Microsoft.AspNetCore.Mvc;

namespace Cerulean.API.Controllers
{
    [ApiController]
    [Route("gateway")]
    public class GatewayController : ControllerBase
    {
        [HttpGet("endpoint")]
        public ActionResult GetGateways()
        {
            return new JsonResult(new string[]
            {
                "ws://127.0.0.1:81"
            });
        }
    }
}
