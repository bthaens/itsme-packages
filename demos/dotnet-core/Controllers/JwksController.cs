using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_api.Controllers
{
    [Route("production/jwks.json")]
    [ApiController]
    public class JwksController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<string> Get()
        {
            var jwks = System.IO.File.ReadAllText("private_jwks.json");
            return Content(jwks, "application/json");
        }
    }
}
