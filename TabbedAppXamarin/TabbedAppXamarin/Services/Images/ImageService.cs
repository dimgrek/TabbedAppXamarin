using System.Threading.Tasks;
using TabbedAppXamarin.Services.Networking;
using Xamarin.Forms;

namespace TabbedAppXamarin.Services.Images
{
    public class ImageService
    {
        private const string GetImageURL = "http://lorempixel.com/";
        private const string ImageWidth = "400";
        private const string ImageHeight = "/400/";
        private readonly IRestClient _restClient;

        public ImageService()
        {
            //_restClient = new RestClient();
        }

        public async Task<ImageSource>ReturnResponce()
        {
            var uri = GetImageURL + ImageWidth + ImageHeight;
            var responce = await _restClient.GetAsync(uri);
            return responce;
        }
    }
}
