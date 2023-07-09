using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingApp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RoutingController : ControllerBase
    {
        [HttpGet("{name:alpha?}")]
        public string Greet(string name)
        {
            return $"hello from contoller {name}";
        }
    }
}
