using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Weather
    {
        // case sensitive nog oplossen
        public double latitude { get; set; }
        public double longitude { get; set; }
        public hourly hourly { get; set; }
    }
}
