using System.Threading.Tasks;
using TabbedAppXamarin.Services.Networking;
using Xamarin.Forms;

namespace TabbedAppXamarin.Services.Images
{
    public class ImageService
    {
        private const string ImageURL = "http://lorempixel.com/";
        private const string ImageWidth = "400/";
        private const string ImageHeight = "400/";
        private readonly IRestClient _restClient;
        private ISaveImageService _di;

        public ImageService()
        {
            _restClient = new RestClient();
            _di = DependencyService.Get<ISaveImageService>();
        }

        public async Task<string> SaveImageLocally(int imageNumber)
        {
            var uri = ImageURL + ImageWidth + ImageHeight;
            var t = await _restClient.GetBytes(uri);
            _di.SaveImageLocally(t, imageNumber);
            return _di.ShowLocalFileName();
        }

        public void SaveImageToGallery(string file)
        {
            _di.SaveImageToGallery(file);
        }
    }
}
