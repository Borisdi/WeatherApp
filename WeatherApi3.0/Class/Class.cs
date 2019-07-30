using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiClass
{
    public class ResponseUVIndex
    {
         public double lat { get; set; }
         public double lon { get; set; }
         public DateTime date_iso { get; set; }
         public int date { get; set; }
         public double value { get; set; }
         public int cnt { get; set; }
    }
}
