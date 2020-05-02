using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Service.Models.OpenWeatherMap
{
    public class ForecastData3H
    {
        public int dt { get; set; }
        public MainForecast main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public RainForecast rain { get; set; }
        public SysForecast sys { get; set; }
        public string dt_txt { get; set; }
    }
}
