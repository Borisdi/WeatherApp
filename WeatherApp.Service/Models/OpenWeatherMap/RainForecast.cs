using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Service.Models.OpenWeatherMap
{
    public class RainForecast
    {
        [JsonProperty("3h")]
        public double Rain3h { get; set; }
    }
}
