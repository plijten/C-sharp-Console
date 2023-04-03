using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp
{
    // kleine letter ivm case sensitive in json file. Nog oplossen.
    public class hourly
    {
        [JsonPropertyName("time")]
        public List<string>? Time { get; set; }

        [JsonPropertyName("rain")]
        public List<double>? Rain { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double>? Temperature_2m { get; set; }
    }
}
