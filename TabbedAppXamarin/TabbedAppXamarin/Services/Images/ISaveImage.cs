namespace TabbedAppXamarin.Services.Images
{
    public interface ISaveImage
    {
        void SaveImageLocally(byte[] bytes, int imageNumber);
        void SaveImageToGallery(string path);
        //void SavePreloader(byte[] bytes, int imageNumber);
        string ShowLocalFileName();
        //string ShowPreloaderFileName();
    }
}
