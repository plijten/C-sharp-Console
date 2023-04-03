﻿using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

class Program
{
    private static readonly string key = "c24c2d690d2e4ac598374bcd21d4acf5";
    private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com";

    // location, also known as region.
    // required if you're using a multi-service or regional (not global) resource. It can be found in the Azure portal on the Keys and Endpoint page.
    private static readonly string location = "westeurope";

    static async Task Main(string[] args)
    {
        // Input and output languages are defined as parameters.
        string route = "/translate?api-version=3.0&from=nl&to=en&to=fr";
        string textToTranslate = "Basketbalster Brittney Griner, die in Rusland vastzit voor drugssmokkel, is overgebracht naar een strafkolonie. Haar advocaat zegt dat niet duidelijk is waar de 31-jarige atlete nu verblijft";
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
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}