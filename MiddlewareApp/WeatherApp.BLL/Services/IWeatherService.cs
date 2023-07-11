using System.Collections.Generic;
using WeatherApp.BLL.Models;

namespace WeatherApp.BLL.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> Get(string city, int NbOfDays);
    }
}