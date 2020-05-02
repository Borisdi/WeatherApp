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
    }
}
