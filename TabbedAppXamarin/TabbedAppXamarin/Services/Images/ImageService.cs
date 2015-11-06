﻿using System;
using System.Threading.Tasks;
using TabbedAppXamarin.Services.Networking;
using Xamarin.Forms;

namespace TabbedAppXamarin.Services.Images
{
    public class ImageService
    {
        private const string ImageURL = "http://lorempixel.com/";
        private const string ImageWidth = "400/";
        private const string PreloaderWidth = "80/";
        private const string ImageHeight = "400/";
        private const string PreloaderHeight = "80/";
        private readonly IRestClient _restClient;
        private IDownloadImage _di;

        public ImageService()
        {
            _restClient = new RestClient();
            _di = DependencyService.Get<IDownloadImage>();
        }

        public event EventHandler ImageDownloaded;

        public async Task<string> SaveImage(int imageNumber)
        {
            var uri = ImageURL + ImageWidth + ImageHeight;
            var t = await _restClient.GetBytes(uri);
            _di.SaveImage(t, imageNumber);
            ImageDownloaded?.Invoke(this, EventArgs.Empty);
            return _di.ShowLocalFileName();
        }

        public async Task<string> SavePreloader(int imageNumber)
        {
            var uri = ImageURL + PreloaderWidth + PreloaderHeight;
            var t = await _restClient.GetBytes(uri);
            _di.SavePreloader(t, imageNumber);
            return _di.ShowPreloaderFileName();
        }

        public void SaveImageToGallery(string path)
        {
            _di.SaveImageToGallery(path);
        }
    }
}
