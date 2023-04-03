using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;
using WeatherApp;

Forecast forcast = new Forecast(new DateTime(2023, 01, 09));

if (forcast == null)
{
    Console.WriteLine("Geen geldige waarde ontvangen.");
    return;
}

// Sla het bericht op in een text bestand.
string stringForcast = forcast.PrintForcast();
Helper.FileWriter("c:\\temp\\weerbericht.txt", stringForcast);

// Vertaal het weerbericht (weggeven aan de studenten)
Translator translator = new Translator();
await translator.TranslateString(stringForcast);
string json = translator.TranslatedString;

List<Translations> vertalingen = JsonConvert.DeserializeObject<List<Translations>>(json);


//Sla vertaalde weerberichten op.
foreach (Translations t in vertalingen)
{
    foreach (var text in t.translations)
    {
        Helper.FileWriter($"c:\\temp\\weerbericht-{text.to}.txt", text.text);
    }

}





