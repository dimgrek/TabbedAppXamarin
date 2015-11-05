using System;
using System.IO;
using System.Net;

namespace TabbedAppXamarin.iOS.Services.Networking
{
    public class DownloadImage
    {
        private WebClient _webClient;

        public DownloadImage()
        {
            _webClient = new WebClient();
        }

        public void SaveImage(string uri)
        {
            string localPath;
            _webClient.DownloadDataCompleted += (s, e) =>
            {
                var bytes = e.Result;
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var localFilename = "downloaded.png";
                localPath = Path.Combine(documentsPath, localFilename);
                Console.WriteLine("localPath:" + localPath);
                File.WriteAllBytes(localPath, bytes);

                //// IMPORTANT: this is a background thread, so any interaction with
                //// UI controls must be done via the MainThread
                //InvokeOnMainThread(() => {

                //    imageView.Image = UIImage.FromFile(localPath);

                //new UIAlertView("Done"
                //    , "Image downloaded and saved."
                //    , null
                //    , "OK"
                //    , null).Show();
                //});
            };
            var url = new Uri(uri);
            _webClient.DownloadDataAsync(url);
        }
    }
}
