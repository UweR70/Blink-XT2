using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Blink.Classes
{
    public class ImisImplementation
    {

        const string baseUrl = "https://server.com/asischedulerv10/";


        public void TestUweR70()
        {
            // http://help.imis.com/sdk/index.htm#!exampleusingc2.htm
        }



        public async Task RestDemo(string baseUrl)
        {
            // Create the client
            using (var client = new HttpClient())
            {
                // Format headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Request token, and append to headers
                await AddTokenToHeaders(client);

                // Query HTTP Service                
                var response = await client.GetAsync(baseUrl + "api/PartySummary/DEE24443-554B-4056-AFB1-2963F0C5E4FE");
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize response to DataContract
                    //var party = await response.Content.ReadAsAsync<PartySummaryData>();
                    var dataString = await response.Content.ReadAsStringAsync();
                    //var party = JsonConvert.DeserializeObject<PartySummaryData>(dataString);
                    //if (party != null)
                    //    Console.WriteLine(party.Name);
                }
            }
        }

        private static async Task AddTokenToHeaders(HttpClient client)
        {
            // POST token request with credentials
            var response = await client.PostAsync(baseUrl + "Token",
                new FormUrlEncodedContent(
                new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", "UweRaatz@gmx.de"),
                    new KeyValuePair<string, string>("password", "SchnEe_+kuchen3-Q"),
                }));

            // Deserialize JSON response to token class
            //var token = await response.Content.ReadAsAsync<Token>();
            var dataString = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<Token>(dataString);
            if (token != null)
            {
                client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token.AccessToken));
            }
        }

        private class Token
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
        }
    }
}
