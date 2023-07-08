using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace ConfigurationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IOptions<MyApiOptions> _apiOptions;

        public WeatherForecastController(IOptions<MyApiOptions> apiOptions)
        {
            _apiOptions = apiOptions;
        }

        [HttpGet]
        public void Get()
        {
            Console.WriteLine("Inside Get method");
            Console.WriteLine($"ApiKey : {_apiOptions.Value.ApiKey}");
            Console.WriteLine($"Url : {_apiOptions.Value.Url}");
            Console.WriteLine($"ApiKeyTopSecret : {_apiOptions.Value.ApiKeyTopSecret}");
        }
    }
}
