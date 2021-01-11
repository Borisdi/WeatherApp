using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            //TODO: YY to config
            var uri = _baseAddress + "/data/2.5/weather" + "?lat=" + latitude.ToString(CultureInfo.InvariantCulture) + "&lon=" + longitude.ToString(CultureInfo.InvariantCulture) + "&APPID=" + _apiKey + "&units=metric" + "&lang=" + language;
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

            throw new Exception($"Error getting current conditions: for {latitude}, {longitude}. Response: {response.StatusCode} - {response.ReasonPhrase}.");
        }

        //TODO: check 
        public async Task<CurrentConditions> GetCurrentConditions(string location, string language)
        {
            var uri = _baseAddress + "/data/2.5/weather" + "?q=" + location + "&APPID=" + _apiKey + "&units=metric" + "&lang=" + language;
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

            throw new Exception($"Error getting current conditions: location {location}. Response: {response.StatusCode} - {response.ReasonPhrase}.");
        }

        public async Task<Forecast> GetForecast(string locationId, string language)
        {
            var uri = _baseAddress + "/data/2.5/forecast" + "?q=" + locationId + "&APPID=" + _apiKey + "&units=metric" + "&lang=" + language;
            var response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var forecast = JsonConvert.DeserializeObject<Models.OpenWeatherMap.Forecast>(content);
                var details = forecast.list.Select(x => new ForecastDetail()
                {
                    Date = x.dt_txt,
                    Clouds = x.clouds.all,
                    Description = x.weather.First()?.description,
                    Id = x.weather.First()?.id,
                    Pressure = x.main.pressure,
                    Rain = x.rain?.Rain3h,
                    Temperature = x.main.temp,
                    WindDegree = x.wind.deg,
                    WindSpeed = x.wind.speed
                })
                    .ToList();
                return new Forecast()
                {
                    City = forecast.city.name,
                    ForecastDetails = details
                };
            }

            throw new Exception($"Error getting Forecast: for lcoationId: {locationId}. Response: {response.StatusCode} - {response.ReasonPhrase}.");
        }

        public async Task<List<UvIndexForecast>> GetUvIndexForecast(double latitude, double longitude, string language)
        {
            var uri = _baseAddress + "/data/2.5/uvi/forecast" + "?lat=" + latitude.ToString(CultureInfo.InvariantCulture) + "&lon=" + longitude.ToString(CultureInfo.InvariantCulture) + "&APPID=" + _apiKey + "&lang=" + language;
            var response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var uvForecast = JsonConvert.DeserializeObject<List<Models.OpenWeatherMap.ResponseUVIndex>>(content);
                var result = uvForecast.Select(x => new UvIndexForecast()
                {
                    Date = x.date_iso,
                    Value = x.value
                });
                return result.ToList();
            }

            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error getting UV Index: for {latitude}, {longitude}. Response: {response.StatusCode} - {response.ReasonPhrase}. {body}");
        }
    }
}
