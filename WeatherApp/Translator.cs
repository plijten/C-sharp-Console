using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp
{
    public class Translator
    {
        // Als code niet meer werkt dan via azure een nieuwe aanmaken. Vraag bij PL om dit te doen.
        // Dan past het in het maandelijks tegoed.
        private readonly string key = "a46f0f90f05c4257ae6384dee3ddae6e"; //LET OP Code geheim houden!
        private readonly string endpoint = "https://api.cognitive.microsofttranslator.com";

        // location, also known as region.
        // required if you're using a multi-service or regional (not global) resource. It can be found in the Azure portal on the Keys and Endpoint page.
        private readonly string location = "westeurope";
        public string? TranslatedString { get; private set; }

        public async Task TranslateString(string textToTranslate)
        {
            string route = "/translate?api-version=3.0&from=nl&to=en&to=fr";
            object[] body = new object[] { new { Text = textToTranslate } };

            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);

                // location required if you're using a multi-service or regional (not global) resource.
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

                // Read response as a string.
                TranslatedString = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
