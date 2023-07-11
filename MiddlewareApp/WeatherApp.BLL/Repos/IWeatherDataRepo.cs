using System.Collections.Generic;
using WeatherApp.BLL.Models;

namespace WeatherApp.BLL.Repos
{
    public interface IWeatherDataRepo
    {
        IEnumerable<WeatherForecast> Get(string city, int NbOfDays);
    }
}