using FilterApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FilterApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ResourceFilter("ProductController", 2)]
    public class ProductController : Controller
    {
        [HttpGet("get")]
        [ResourceFilter("Get")]
        [ActionFilter("Get")]
        public string Get()
        {
            return "ProductController Get";
        }

        [HttpGet("GetResult")]
        //[ServiceFilter(typeof(ResultFilterAttribute))]
        [TypeFilter(typeof(ResultFilterAttribute), Arguments = new object[] { "action GetResult" })]
        public string GetResult()
        {
            return "ProductController GetResult";
        }
    }
}
