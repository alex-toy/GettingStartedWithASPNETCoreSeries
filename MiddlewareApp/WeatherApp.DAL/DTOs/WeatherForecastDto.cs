using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.DAL.DTOs
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
