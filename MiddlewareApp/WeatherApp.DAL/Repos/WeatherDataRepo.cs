using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.BLL.Models;
using WeatherApp.BLL.Repos;
using WeatherApp.DAL.DTOs;
using WeatherApp.DAL.Mappers;

namespace WeatherApp.DAL
{
    public class WeatherDataRepo : IWeatherDataRepo
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> Get(string city, int NbOfDays)
        {
            var rng = new Random();
            IEnumerable<WeatherForecastDto> weatherForecastDtos =  Enumerable.Range(1, NbOfDays).Select(index => new WeatherForecastDto
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureCelsius = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            IEnumerable<WeatherForecast> weatherForecasts = weatherForecastDtos.Map();

            return weatherForecasts;
        }
    }
}
