using System;
using System.IO;
using TabbedAppXamarin.iOS.Services.Images;
using TabbedAppXamarin.Services.Images;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveImage))]
namespace TabbedAppXamarin.iOS.Services.Images
{
    public class SaveImage : ISaveImage
    {
        private const string ImageType = ".png";
        private string _localPath;
        private string _preloaderPath;
        public string LocalPath { get { return _localPath;} set { _localPath = value; } }

        //public string PreloaderPath { get { return _preloaderPath; } set { _preloaderPath = value; } }

        public void SaveImageLocally(byte[] bytes, int imageNumber)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var localFilename = "downloaded" + imageNumber + ImageType;
            LocalPath = Path.Combine(documentsPath, localFilename);
            File.WriteAllBytes(LocalPath, bytes);
        }

        public string ShowLocalFileName()
        {
            return _localPath;
        }


        public void SaveImageToGallery(string path)
        {
           //todo: create UIImage
            var someImage = UIImage.FromFile(path);
            someImage.SaveToPhotosAlbum((image, error) => {
                var o = image;
                Console.WriteLine("error:" + error);
            });
        }

        //    var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //{

        //public void SavePreloader(byte[] bytes, int imageNumber)
        //}
        //    return _preloaderPath;
        //{


        //public string ShowPreloaderFileName()
        //    var localFilename = "downloadedPreloader" + imageNumber + ImageType;
        //    PreloaderPath = Path.Combine(documentsPath, localFilename);
        //    File.WriteAllBytes(PreloaderPath, bytes);
        //}
    }
}
