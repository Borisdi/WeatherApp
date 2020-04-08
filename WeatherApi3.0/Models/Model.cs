using System.Collections.Generic;
using WeatherApiClass;

namespace WeatherApiModel
{
    public class OpenWeatherMap
    {
    public ResponseWeather CurrentWeatherConditions { get; set; }

    public ResponseForecast Forecast { get; set; }

    public List<ResponseUVIndex>  UVIndexForecast { get; set; }
    }
}
