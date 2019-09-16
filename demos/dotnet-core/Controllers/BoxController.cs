using Microsoft.AspNetCore.Mvc;
using dotnet_core_api.Integrations;

namespace dotnet_core_api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BoxController : ControllerBase
    {
        private IItsmeClient _itsmeClient;
        public BoxController(IItsmeClient itsmeClient)
        {
            _itsmeClient = itsmeClient;
        }

        [HttpGet()]
        public ActionResult<Itsme.User> Val([FromQuery(Name = "code")] string code, string error, string error_description)
        {
            return _itsmeClient.GetUserDetails(code);
        }

        [HttpGet()]
        public ActionResult<string> Get()
        {
            var jwks = System.IO.File.ReadAllText("jwks_private.json");
            return Content(jwks, "application/json");
        }
        [HttpGet()]
        public ActionResult<string> Test()
        {
            var jwks = System.IO.File.ReadAllText("jwks_private.json");
            return Content("{test:hoi}", "application/json");
        }
        [HttpGet()]
        [ActionName("Cred/jwks.json")]
        public ActionResult<string> Jwks()
        {
            var jwks = System.IO.File.ReadAllText("jwks_private.json");
            return Content(jwks, "application/json");
        }
    }
}
