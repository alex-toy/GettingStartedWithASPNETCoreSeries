using ExceptionHandling.Domain.Models;
using ExceptionHandling.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionHandlingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<WeatherForecast>> Get(string city)
        //{
        //    try
        //    {
        //        if (city == "rome") throw new Exception("no valid data for rome");

        //        var rng = new Random();
        //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //        {
        //            Date = DateTime.Now.AddDays(index),
        //            TemperatureC = rng.Next(-20, 55),
        //            Summary = Summaries[rng.Next(Summaries.Length)]
        //        })
        //        .ToArray();
        //    }
        //    catch (Exception e)
        //    {
        //        //return BadRequest(e.Message);
        //        return NotFound(e.Message);
        //    }
        //}

        [HttpGet("middleware")]
        public ActionResult<IEnumerable<WeatherForecast>> GetMiddleware(string city)
        {
            return _weatherService.Get(city).ToArray();
        }
    }
}
