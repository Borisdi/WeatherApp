using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Service.Models.Output;

namespace WeatherApi3.Models
{
    public class AllWeatherModel
    {
        public CurrentConditions CurrentWeatherConditions { get; set; }

        public Forecast Forecast { get; set; }

        public List<UvIndexForecast> UVIndexForecast { get; set; }
    }
}
