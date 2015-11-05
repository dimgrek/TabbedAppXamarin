using System;
using System.IO;
using TabbedAppXamarin.iOS.Services.Networking;
using TabbedAppXamarin.Services.Images;
using Xamarin.Forms;

[assembly: Dependency(typeof(DownloadImage))]
namespace TabbedAppXamarin.iOS.Services.Networking
{
    public class DownloadImage : IDownloadImage
    {
        private const string ImageType = ".png";
        private string _localPath;
        public string LocalPath { get { return _localPath;} set { _localPath = value; } }

        public void SaveImage(byte[] bytes, int imageNumber)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var localFilename = "downloaded" + imageNumber + ImageType;
            LocalPath = Path.Combine(documentsPath, localFilename);
            File.WriteAllBytes(LocalPath, bytes);
            

            //_webClient.DownloadDataCompleted += (s, e) =>
            //{
            //    var bytes = e.Result;
            //    var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //    var localFilename = "downloaded.png";
            //    localPath = Path.Combine(documentsPath, localFilename);
            //    Console.WriteLine("localPath:" + localPath);
            //    File.WriteAllBytes(localPath, bytes);

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

            //var url = new Uri(uri);
            //_webClient.DownloadDataAsync(url);
        }

        public string ShowLocalFileName()
        {
            return _localPath;
        }
    }
}
