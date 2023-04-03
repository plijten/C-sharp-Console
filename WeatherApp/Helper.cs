using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public static class Helper
    {
        public static void FileWriter(string filePath, string text)
        {
            // Bestaat het bestand, dan gooien we het gewoon weg. 
            // ToDo: betere afhandeling maken.
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using StreamWriter streamWriter= new StreamWriter(filePath);
            streamWriter.Write(text);
        }

    }
}
