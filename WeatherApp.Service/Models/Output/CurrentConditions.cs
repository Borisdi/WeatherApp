using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Service.Models.OpenWeatherMap;

namespace WeatherApp.Service.Models.Output
{
    public class CurrentConditions
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public double WindDegree { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public string Name { get; set; }
    }
}
