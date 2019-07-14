using System.Collections.Generic;
using WeatherApiClass;

namespace WeatherApiModel
{
    public class OpenWeatherMap
    {
    public ResponseWeatherList CurrentWeatherConditions { get; set; }

    public ResponseForecast Forecast { get; set; }
    }
}
