using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILogger<WeatherForecast> _loggerWF;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            ILogger<WeatherForecast> loggerWF)
        {
            _logger = logger;
            _loggerWF = loggerWF;
            _logger.Log(LogLevel.Information, "Hello from the weather controller");
            _loggerWF.LogCritical("Hello from the weather object");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Random rng = new Random();

            _logger.LogInformation("weather information {temp}", rng.Next());
            _logger.LogTrace("This is a trace message");

            using (_logger.BeginScope(new Dictionary<string, object> { { "PersonId", 5} }))
            {
                _logger.LogInformation("hello");
                _logger.LogInformation("world");
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
