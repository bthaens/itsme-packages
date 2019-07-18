using Microsoft.AspNetCore.Mvc;
using dotnet_core_api.Integrations;

namespace dotnet_core_api.Controllers
{
    [Route("production/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IItsmeClient _itsmeClient;
        public LoginController(IItsmeClient itsmeClient)
        {
            _itsmeClient = itsmeClient;
        }

        [HttpGet()]
        public ActionResult<string> Get()
        {
            return Content($"{{\"url\": \"{_itsmeClient.GetLoginUrl()}\"}}", "application/json");
        }
    }
}
