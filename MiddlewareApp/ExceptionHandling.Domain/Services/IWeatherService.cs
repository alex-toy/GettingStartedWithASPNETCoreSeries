using ExceptionHandling.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExceptionHandling.Domain.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> Get(string city);
    }
}