using System.Collections.Generic;
using System.Linq;
using WeatherApp.BLL.Models;
using WeatherApp.DAL.DTOs;

namespace WeatherApp.DAL.Mappers
{
    public static class WeatherForecastMapper
    {
        public static WeatherForecast Map(this WeatherForecastDto weatherForecastDto)
        {
            WeatherForecast weatherForecast = new WeatherForecast()
            {
                Date = weatherForecastDto.Date,
                Summary = weatherForecastDto.Summary,
                TemperatureC = weatherForecastDto.TemperatureCelsius
            };

            return weatherForecast;
        }

        public static IEnumerable<WeatherForecast> Map(this IEnumerable<WeatherForecastDto> weatherForecastDtos)
        {
            IEnumerable<WeatherForecast> weatherForecasts = weatherForecastDtos.Select(weatherForecastDto => weatherForecastDto.Map());

            return weatherForecasts;
        }
    }
}
