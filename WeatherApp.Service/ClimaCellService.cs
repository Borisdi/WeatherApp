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
    }
}
