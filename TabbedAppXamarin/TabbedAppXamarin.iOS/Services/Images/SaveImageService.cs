using System;
using System.IO;
using TabbedAppXamarin.iOS.Services.Images;
using TabbedAppXamarin.Services.Images;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveImageService))]
namespace TabbedAppXamarin.iOS.Services.Images
{
    public class SaveImageService : ISaveImageService
    {
        private const string ImageType = ".png";
        public string LocalPath { get; set; }

        public void SaveImageLocally(byte[] bytes, int imageNumber)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var localFilename = "downloaded" + imageNumber + ImageType;
            LocalPath = Path.Combine(documentsPath, localFilename);
            File.WriteAllBytes(LocalPath, bytes);
        }

        public string ShowLocalFileName()
        {
            return LocalPath;
        }


        public void SaveImageToGallery(string file)
        {
            var someImage = UIImage.FromFile(file);
            someImage.SaveToPhotosAlbum((image, error) => {
                var o = image;
                Console.WriteLine("error:" + error);
            });
        }
    }
}
