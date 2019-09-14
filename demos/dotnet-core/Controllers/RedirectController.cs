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
    }
}
