using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RefitTest
{
    public class ApiService : IApiService
    {
        private IApi _api;

        public ApiService(IApi api)
        {
            _api = api;
        }

        public async Task<string> GetHeaderAsync(string header)
        {
            var headerAsync = await _api.GetHeader(header);
            return headerAsync.Value;
        }

        public string GetHeader(string header)
        {
            string returnValue = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:62675/api/Header"),
                    Method = HttpMethod.Get
                };
                request.Headers.Add("x-header", "foobar");
                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    returnValue = JsonConvert.DeserializeObject<ApiString>(json).Value;
                }
                return returnValue;
            }
        }
    }
}
