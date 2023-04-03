using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Forecast
    {
        public Location Location { get; set; }
        public DateTime Day { get; private set; }
        public double RainInMm { get; private set; }
        public double AverageTemp { get; private set; }


        public Forecast(DateTime day)
        {
            Weather weather = GetForecast(day);

            Day = day;
            if (weather.hourly.Rain.Count > 0)
                RainInMm = weather.hourly.Rain.Average();
            
            //if (weather.hourly.Temperature_2m > 0)
            //    AverageTemp = weather.hourly.Temperature_2m.Average();

            Location = new Location(weather.latitude.ToString(), weather.longitude.ToString());
        }

        /// <summary>
        /// Toon de gegevens van een weerbericht. 
        /// </summary>
        /// <returns>string van het weerbericht.</returns>
        public String PrintForcast()
        {
            string bericht = $"Weerbericht voor {WeekHelper.GetDagByWeekday((int)Day.DayOfWeek)} {Day.ToString("dd-MM-yyyy")}";
            bericht += Environment.NewLine;
            bericht += $"Latitude voor: {Location.Latitude}";
            bericht += $"Weerbericht voor: {Location.Longitude}";
            bericht += Environment.NewLine;
            bericht += $"Er is {RainInMm} mm regen gevallen.";

            return bericht;
        }

        private Weather GetForecast(DateTime startDate)
        {
            string startDateString = startDate.ToString("yyyy-MM-dd");

            var client = new HttpClient();
            string api = $"https://api.open-meteo.com/v1/forecast?latitude=52.27&longitude=6.79&hourly=temperature_2m,rain,snowfall&daily=temperature_2m_max,temperature_2m_min,sunrise,sunset&timezone=Europe%2FBerlin";
            client.BaseAddress = new Uri(api);
            // URL zonder de ID van de pokemon (Basis URL)           
            //client.BaseAddress = new Uri($"https://api.open-meteo.com/v1/forecast?latitude=52.36&longitude=6.59&hourly=temperature_2m,rain&daily=sunrise,sunset&timezone=Europe%2FBerlin&start_date={startDateString}&end_date={startDateString}");

            var response = client.GetAsync("").Result;
            string json = response.Content.ReadAsStringAsync().Result;

            Weather weather = JsonSerializer.Deserialize<Weather>(json);

            return weather;
        }
    }
}
