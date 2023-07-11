using System.Collections.Generic;
using WeatherApp.BLL.Models;
using WeatherApp.BLL.Repos;

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
            IEnumerable<WeatherForecast> forecasts = _weatherDataRepo.Get(city, NbOfDays);
            return forecasts;
        }
    }
}
