using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Service.Interfaces;
using WeatherApp.Service.Models.Output;

namespace WeatherApp.Service
{
    public class OpenWeatherMapService : IWeatherService
    {
        private readonly string _baseAddress;
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public OpenWeatherMapService(string baseAddress, string key, HttpClient httpClient)
        {
            _baseAddress = baseAddress;
            _apiKey = key;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_baseAddress);
        }

        public async Task<CurrentConditions> GetCurrentConditions(double latitude, double longitude, string language)
        {
            //TODO: to config
            var uri = _baseAddress + "/data/2.5/weather" + "?lat=" + latitude + "&lon=" + longitude + "&APPID=" + _apiKey + "&units=metric" + "&lang=" + language;
            var response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var cond = JsonConvert.DeserializeObject<Models.OpenWeatherMap.CurrentConditions>(content);
                return new CurrentConditions()
                {
                    Description = cond.weather[0].description,
                    Humidity = cond.main.humidity,
                    Id = cond.weather[0].id,
                    Name = cond.name,
                    Pressure = cond.main.pressure,
                    Temp = cond.main.temp,
                    WindDegree = cond.wind.deg,
                    WindSpeed = cond.wind.speed,
                    Sunrise = cond.sys.sunrise,
                    Sunset = cond.sys.sunset
                };
            }
            else
            {
                throw new Exception($"Error getting current conditions: for {latitude}, {longitude}. Response: {response.StatusCode} - {response.ReasonPhrase}.");
            }
        }
    }
}
