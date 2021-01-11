using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Service.Models.Output;

namespace WeatherApp.Service.Interfaces
{
    public interface IWeatherService
    {
        Task<CurrentConditions> GetCurrentConditions(double latitude, double longitude, string language);
        Task<CurrentConditions> GetCurrentConditions(string location, string language);
        Task<List<UvIndexForecast>> GetUvIndexForecast(double latitude, double longitude, string language);
        Task<Forecast> GetForecast(string locationId, string language);
    }
}
