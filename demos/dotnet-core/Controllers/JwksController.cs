using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_api.Controllers
{
    [Route("jwks.json")]
    [ApiController]
    public class JwksController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<string> Get()
        {
            var jwks = System.IO.File.ReadAllText("jwks_private.json");
            return Content(jwks, "application/json");
        }
    }
}
