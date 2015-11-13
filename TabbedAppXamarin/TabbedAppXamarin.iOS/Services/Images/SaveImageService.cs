using System;
using System.IO;
using FFImageLoading.Transformations;
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

        public byte[] TransformImage(FlipType type, string file)
        {
            var ft = new FlipTransformation(type);
            var transformedImage = ft.TransformFromFile(file);
            byte[] myByteArray;
            using (var imageData = transformedImage.AsJPEG())
            {
                myByteArray = new byte[imageData.Length];
                System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteArray, 0, Convert.ToInt32(imageData.Length));
            }
            return myByteArray;
        }

        public void SaveTrasnformedImage(UIImage source)
        {
            byte[] myByteArray;
            using (var imageData = source.AsPNG())
            {
                myByteArray = new byte[imageData.Length];
                System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteArray, 0, Convert.ToInt32(imageData.Length));
            }
            SaveImageLocally(myByteArray, 101);
        }

        public void SaveUiImageToGallery(UIImage source)
        {
            source.SaveToPhotosAlbum((image, error) => {
                var o = image;
                Console.WriteLine("error:" + error);
            });
        }
    }
}
