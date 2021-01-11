using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApi3.Models;
using WeatherApp.Service.Interfaces;
using WeatherApp.Service.Models.Output;

namespace WeatherApi3._0.Controllers
{
    public class OpenWeatherMapMvcController : Controller
    {
        const string bgLanguage = "bg";
        const string LocationSofia = "Sofia";
        const string LocationPlovdiv = "Plovdiv";
        const string LocationBurgas = "Burgas";

        const int LocationSofiaID = 727011;
        const int LocationPlovdivID = 728193;
        const int LocationBurgasID = 732771;
        
        const double SofiaCoordLat = 42.7;
        const double SofiaCoordLon = 23.32;

        private readonly IWeatherService _openWeatherMap;

        public OpenWeatherMapMvcController(IWeatherService openWeatherMapService)
        {
            _openWeatherMap = openWeatherMapService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //TODO: latitude needed?
            double latitude = 42.7;
            double longitude = 23.32;
            //TODO: group path - what is in there, needed?
            //HttpWebRequest URL = WebRequest.Create("http://api.openweathermap.org/data/2.5/group?id=" + LocationSofiaID + "&APPID=" + APIkey + "&units=metric" + "&lang=bg") as HttpWebRequest;
            var currentConditions = await _openWeatherMap.GetCurrentConditions(LocationSofia, bgLanguage);
            var forecast = await _openWeatherMap.GetForecast(LocationSofia, bgLanguage);
            var uvForecast = await _openWeatherMap.GetUvIndexForecast(SofiaCoordLat, SofiaCoordLon, bgLanguage);
            var result = new AllWeatherModel()
            {
                CurrentWeatherConditions = currentConditions,
                Forecast = forecast,
                UVIndexForecast = uvForecast
            };

            return View(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCurrentConditionsAndForecast(double latitude, double longitude)
        {
            try
            {
                var currentConditions = await _openWeatherMap.GetCurrentConditions(latitude, longitude, "bg");
                return View("_CurrentLocationConditions", currentConditions);
            }
            catch (Exception e)
            {
                //TODO: YY
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAnalysis()
        {  
            return View("_Analysis");
        }
        
        [HttpGet]
        public string Error()
        {
            string ErrorMessage = "Oops something went wrong";
            return ErrorMessage;
        }
    }
}