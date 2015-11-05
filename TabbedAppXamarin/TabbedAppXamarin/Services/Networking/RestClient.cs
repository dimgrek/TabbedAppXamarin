using System.Net.Http;
using System.Threading.Tasks;

namespace TabbedAppXamarin.Services.Networking
{
    public class RestClient : IRestClient
    {
        public async Task<byte[]> GetBytes(string uri)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(uri))
                {
                    var byteArray = await response.Content.ReadAsByteArrayAsync();
                    return byteArray;
                }
            }
        }
    }
}
