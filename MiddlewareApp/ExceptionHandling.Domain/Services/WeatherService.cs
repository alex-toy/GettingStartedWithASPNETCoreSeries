using ExceptionHandling.Domain.Exceptions;
using ExceptionHandling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionHandling.Domain.Services
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> Get(string city)
        {
            if (city == "rome") throw new DomainNotFoundException("no valid data for rome");
            if (city == "paris") throw new ValidationException("no valid data for paris");

            var rng = new Random();
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
