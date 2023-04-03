using Newtonsoft.Json;
TranslatorLib.Translator vertaal = new TranslatorLib.Translator();

vertaal.TranslateString("Hallo dit is een test");
Console.WriteLine(vertaal.TranslatedString);