using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WeatherApp.BLL.Models;
using WeatherApp.BLL.Services;

namespace LayeringApp.Controllers
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(string city = "rome", int NbOfDays = 3)
        {
            return _weatherService.Get(city, NbOfDays);
        }
    }
}
