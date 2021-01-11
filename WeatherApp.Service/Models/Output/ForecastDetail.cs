using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Service.Models.Output
{
    public class ForecastDetail
    {
        public string Date { get; set; }
        public int? Id { get; set; }
        public string Description { get; set; }
        public double Temperature { get; set; }
        public int Clouds { get; set; }
        public double? Rain { get; set; }
        public double WindDegree { get; set; }
        public double WindSpeed { get; set; }
        public double Pressure { get; set; }
    }
}
