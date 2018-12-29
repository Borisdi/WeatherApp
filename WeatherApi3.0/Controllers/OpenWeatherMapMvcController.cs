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
                HttpWebRequest URL = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + LocationSofia + "&APPID=" + APIkey + "&units=metric") as HttpWebRequest;
                string apiResponse = "";
                 using (HttpWebResponse response = URL.GetResponse() as HttpWebResponse)
                 {
                     StreamReader reader = new StreamReader(response.GetResponseStream());
                     apiResponse = reader.ReadToEnd();
                 }

                ResponseWeather rootObject = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);
                return View(rootObject);
        }
        [HttpGet]
        public string Error() {
            string ErrorMessage = "Ops something went wrong";
            return ErrorMessage;
        }
    }
}