using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Service.Models.OpenWeatherMap
{
    public class Main
    {
        public double temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }
}
