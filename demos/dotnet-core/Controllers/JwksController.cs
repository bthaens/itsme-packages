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
            var jwks = System.IO.File.ReadAllText("../keys/jwks_private.json");
            return Content(jwks, "application/json");
        }
    }
}
