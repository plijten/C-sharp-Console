﻿using System.Text.Json;

class Program
{
    public static void Main()
    {
        var weatherForecast = new WeatherForecast
        {
            Date = DateTime.Parse("2019-08-01"),
            TemperatureCelsius = 25,
            Summary = "Hot"
        };

        string jsonString = JsonSerializer.Serialize(weatherForecast);
        File.WriteAllText("c:\\temp\\weerbericht.json", jsonString);

        string test = File.ReadAllText("c:\\temp\\weerbericht.json");
        var weatherForecast1 = JsonSerializer.Deserialize<WeatherForecast>(test);

        //Console.WriteLine(jsonString);
    }

}

public class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string? Summary { get; set; }
}
