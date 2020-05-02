using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Service.Models.OpenWeatherMap;
using WeatherApp.Service.Interfaces;

namespace WeatherApi3._0.Controllers
{
    public class OpenWeatherMapMvcController : Controller
    {
        private readonly IWeatherService _openWeatherMap;

        public OpenWeatherMapMvcController(IWeatherService openWeatherMapService)
        {
            _openWeatherMap = openWeatherMapService;
        }

        private string APIkey = "6d85a7afd458036f67cfcce6e5c8815f";
    
        [HttpGet]
        public IActionResult Index()
        {          
            string LocationSofia = "Sofia";
            string LocationPlovdiv = "Plovdiv";
            string LocationBurgas = "Burgas";
            int LocationSofiaID = 727011;
            int LocationPlovdivID = 728193;
            int LocationBurgasID = 732771;
            double latitude = 42.7;
            double longitude = 23.32;
            HttpWebRequest URL = WebRequest.Create("http://api.openweathermap.org/data/2.5/group?id=" + LocationSofiaID + "&APPID=" + APIkey + "&units=metric" + "&lang=bg") as HttpWebRequest;
            //HttpWebRequest URL = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + LocationSofia + "&APPID=" + APIkey + "&units=metric" + "&lang=bg") as HttpWebRequest;
            //HttpWebRequest URL = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather" + "?lat=" + latitude + "&lon=" + longitude + "&APPID=" + APIkey + "&units=metric" + "&lang=bg") as HttpWebRequest;
            string apiResponse = "";
            using (HttpWebResponse response = URL.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            WeatherList rootObject = JsonConvert.DeserializeObject<WeatherList>(apiResponse);
            OpenWeatherMap Model = new OpenWeatherMap()
            {
                CurrentWeatherConditions = rootObject.list.FirstOrDefault(),
                Forecast = GetForecast(),
                UVIndexForecast = GetUVIndexForecast()
            };
            return View(Model);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCurrentConditionsAndForecast(double latitude, double longitude)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.openweathermap.org");
            var uri = "http://api.openweathermap.org/data/2.5/weather" + "?lat=" + latitude + "&lon=" + longitude + "&APPID=" + APIkey + "&units=metric" + "&lang=bg";
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var currentConditions = JsonConvert.DeserializeObject<CurrentConditions>(content);
                return View("_CurrentLocationConditions", currentConditions);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAnalysis()
        {  
            return View("_Analysis");
        }
        /* http://api.openweathermap.org/data/2.5/forecast?q=Sofia&APPID=6d85a7afd458036f67cfcce6e5c8815f&units=metric */

        private Forecast GetForecast()
        {
            string LocationSofia = "Sofia";
            string LocationPlovdiv = "Plovdiv";
            string LocationBurgas = "Burgas";
            int LocationSofiaID = 727011;
            int LocationPlovdivID = 728193;
            int LocationBurgasID = 732771;
            HttpWebRequest URL = WebRequest.Create("http://api.openweathermap.org/data/2.5/forecast?q=" + LocationSofia + "&APPID=" + APIkey + "&units=metric" + "&lang=bg") as HttpWebRequest;
            string apiResponseforecast = "";
            using (HttpWebResponse response = URL.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponseforecast = reader.ReadToEnd();
            }

            var rootObject = JsonConvert.DeserializeObject<Forecast>(apiResponseforecast);
            return rootObject;
        }

        private List<ResponseUVIndex> GetUVIndexForecast()
        {
            String SofiaCoordLat = "42.69";
            String SofiaCoordLon = "23.32";
            HttpWebRequest URL = WebRequest.Create("http://api.openweathermap.org/data/2.5/uvi/forecast?" + "appid=" + APIkey + "&lat=" + SofiaCoordLat + "&lon=" + SofiaCoordLon + "&lang=bg") as HttpWebRequest;
            string apiResponseUVIndexForecast = "";
            using (HttpWebResponse response = URL.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponseUVIndexForecast = reader.ReadToEnd();
            }

            List<ResponseUVIndex> rootObject = JsonConvert.DeserializeObject<List<ResponseUVIndex>>(apiResponseUVIndexForecast);
            return rootObject;
        }

        [HttpGet]
        public string Error()
        {
            string ErrorMessage = "Oops something went wrong";
            return ErrorMessage;
        }
    }
}