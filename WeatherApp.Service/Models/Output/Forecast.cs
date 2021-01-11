using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Service.Models.Output
{
    public class Forecast
    {
        public List<ForecastDetail> ForecastDetails { get; set; }
        public string City { get; set; }
    }
}
