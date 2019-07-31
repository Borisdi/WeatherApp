using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using WeatherApiClass;
using System.Text;
using WeatherApiModel;

namespace WeatherApi3._0.Controllers
{
    public class OpenWeatherMapMvcController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string APIkey = "6d85a7afd458036f67cfcce6e5c8815f";
            string LocationSofia = "Sofia";
            string LocationPlovdiv = "Plovdiv";
            string LocationBurgas = "Burgas";
            int LocationSofiaID = 727011;
            int LocationPlovdivID = 728193;
            int LocationBurgasID = 732771;
            // HttpWebRequest URL = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + LocationSofia + "&APPID=" + APIkey + "&units=metric") as HttpWebRequest;
            HttpWebRequest URL = WebRequest.Create("http://api.openweathermap.org/data/2.5/group?id=" + LocationSofiaID + "," + LocationPlovdivID + "," + LocationBurgasID + "&APPID=" + APIkey + "&units=metric") as HttpWebRequest;
            string apiResponse = "";
            using (HttpWebResponse response = URL.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            ResponseWeatherList rootObject = JsonConvert.DeserializeObject<ResponseWeatherList>(apiResponse);
            OpenWeatherMap Model = new OpenWeatherMap()
            {
                CurrentWeatherConditions = rootObject,
                Forecast = GetForecast(),
                UVIndexForecast = GetUVIndexForecast()
            };
            return View(Model);
    }
    /* http://api.openweathermap.org/data/2.5/forecast?q=Sofia&APPID=6d85a7afd458036f67cfcce6e5c8815f&units=metric */

    private ResponseForecast GetForecast()
    {
        string APIkey = "6d85a7afd458036f67cfcce6e5c8815f";
        string LocationSofia = "Sofia";
        string LocationPlovdiv = "Plovdiv";
        string LocationBurgas = "Burgas";
        int LocationSofiaID = 727011;
        int LocationPlovdivID = 728193;
        int LocationBurgasID = 732771;
        HttpWebRequest URL = WebRequest.Create("http://api.openweathermap.org/data/2.5/forecast?q=" + LocationSofia + "&APPID=" + APIkey + "&units=metric") as HttpWebRequest;
        string apiResponseforecast = "";
        using (HttpWebResponse response = URL.GetResponse() as HttpWebResponse)
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            apiResponseforecast = reader.ReadToEnd();
        }

        ResponseForecast rootObject = JsonConvert.DeserializeObject<ResponseForecast>(apiResponseforecast);
        return rootObject;
    }

    private List<ResponseUVIndex> GetUVIndexForecast()
    {
        string APIkey = "6d85a7afd458036f67cfcce6e5c8815f";
        String SofiaCoordLat = "42.69";
        String SofiaCoordLon = "23.32";
        HttpWebRequest URL = WebRequest.Create("http://api.openweathermap.org/data/2.5/uvi/forecast?" + "appid=" + APIkey + "&lat=" + SofiaCoordLat + "&lon=" + SofiaCoordLon) as HttpWebRequest;                                                
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