﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Service.Models.OpenWeatherMap
{
    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
