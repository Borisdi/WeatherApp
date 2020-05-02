using System.Collections.Generic;

namespace WeatherApp.Service.Models.OpenWeatherMap
{
    public class OpenWeatherMap
    {
        public CurrentConditions CurrentWeatherConditions { get; set; }

        public Forecast Forecast { get; set; }

        public List<ResponseUVIndex> UVIndexForecast { get; set; }
    }
}
