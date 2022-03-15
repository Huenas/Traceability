using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fr.Emmanuel.TracabilityUI.Tools
{
    public class TracabilityHTTPClient : HttpClient
    {
        public TracabilityHTTPClient()
        {
            this.BaseAddress = new Uri("https://localhost:44304/api/");

            //this.BaseAddress = new Uri("https://localhost:44337/api/");
            
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }


    }
}
