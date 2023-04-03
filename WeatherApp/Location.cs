using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Location
    {
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        public Location(string latitude, string longitude)
        {
            Latitude = latitude;    
            Longitude = longitude;
        }
    }
}
