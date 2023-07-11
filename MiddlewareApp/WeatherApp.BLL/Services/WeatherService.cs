using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.BLL.Models;
using WeatherApp.DAL;
using WeatherApp.DAL.DTOs;

namespace WeatherApp.BLL.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherDataRepo _weatherDataRepo;

        public WeatherService(IWeatherDataRepo weatherDataRepo)
        {
            _weatherDataRepo = weatherDataRepo;
        }

        public IEnumerable<WeatherForecast> Get(string city, int NbOfDays)
        {
            IEnumerable<WeatherForecastDto> weatherForecastDtos = _weatherDataRepo.Get(city, NbOfDays);
            IEnumerable<WeatherForecast> forecasts = Mapper(weatherForecastDtos);
            return forecasts;
        }

        private static IEnumerable<WeatherForecast> Mapper(IEnumerable<WeatherForecastDto> weatherForecastDtos)
        {
            IEnumerable<WeatherForecast> forecasts = weatherForecastDtos.Select(f => new WeatherForecast()
            {
                Date = f.Date,
                Summary = f.Summary,
                TemperatureC = f.TemperatureC
            });

            return forecasts;
        }
    }
}
