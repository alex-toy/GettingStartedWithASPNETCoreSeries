using FilterApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FilterApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return "hello world";
        }

        [HttpGet("getbis")]
        [MySampleActionFilter("GetBis", 1)]
        public string GetBis()
        {
            return "hello world bis";
        }

        [HttpGet("getter")]
        [MySampleAsyncActionFilter("GetTer")]
        public string GetTer()
        {
            return "hello world ter";
        }
    }
}
