using FilterApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FilterApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [MySampleAsyncActionFilter("Home")]
    public class HomeController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return "hello world from home";
        }
    }
}
