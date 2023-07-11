using System.Collections.Generic;
using WeatherApp.DAL.DTOs;

namespace WeatherApp.DAL
{
    public interface IWeatherDataRepo
    {
        IEnumerable<WeatherForecastDto> Get(string city, int NbOfDays);
    }
}