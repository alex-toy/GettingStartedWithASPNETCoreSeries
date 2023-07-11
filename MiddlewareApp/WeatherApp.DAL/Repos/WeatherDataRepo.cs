using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.DAL.DTOs;

namespace WeatherApp.DAL
{
    public class WeatherDataRepo : IWeatherDataRepo
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecastDto> Get(string city, int NbOfDays)
        {
            var rng = new Random();
            return Enumerable.Range(1, NbOfDays).Select(index => new WeatherForecastDto
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
