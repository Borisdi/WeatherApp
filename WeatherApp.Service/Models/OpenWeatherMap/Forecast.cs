using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Service.Models.OpenWeatherMap
{
    public class Forecast
    {
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<ForecastData3H> list { get; set; }
        public City city { get; set; }
    }
}
