using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Service.Interfaces;
using WeatherApp.Service.Models.Output;

namespace WeatherApp.Service
{
    public class ClimaCellService : IWeatherService
    {
        public Task<CurrentConditions> GetCurrentConditions(double latitude, double longitude, string language)
        {
            throw new NotImplementedException();
        }

        public Task<CurrentConditions> GetCurrentConditions(string location, string language)
        {
            throw new NotImplementedException();
        }

        public Task<Forecast> GetForecast(string locationId, string language)
        {
            throw new NotImplementedException();
        }

        public Task<List<UvIndexForecast>> GetUvIndexForecast(double latitude, double longitude, string language)
        {
            throw new NotImplementedException();
        }
    }
}
