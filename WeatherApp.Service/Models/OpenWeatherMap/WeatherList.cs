using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Service.Models.OpenWeatherMap
{
    public class WeatherList
    {
        public int cnt;
        public List<CurrentConditions> list;
    }
}
