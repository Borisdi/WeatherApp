using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiClass
{
    public class MainForecast
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class WeatherForecast
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class CloudsForecast
    {
        public int all { get; set; }
    }

    public class WindForecast
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class RainForecast
    {
        public double __invalid_name__3h { get; set; }
    }

    public class SysForecast
    {
        public string pod { get; set; }
    }

    public class ForecastData3H
    {
        public int dt { get; set; }
        public MainForecast main { get; set; }
        public List<WeatherForecast> weather { get; set; }
        public CloudsForecast clouds { get; set; }
        public WindForecast wind { get; set; }
        public RainForecast rain { get; set; }
        public SysForecast sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
    }

    public class ResponseForecast
    {
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<ForecastData3H> list { get; set; }
        public City city { get; set; }
    }
}
