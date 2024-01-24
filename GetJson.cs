using System.Net.Http;
using System.Threading.Tasks;

namespace Cargo_Tracking_Application
{
    public class GetJson
    {
        private readonly HttpClient _httpClient;

        public GetJson(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetJsonFromGitHub(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            // Handle error cases
            return null;
        }


    }
}
