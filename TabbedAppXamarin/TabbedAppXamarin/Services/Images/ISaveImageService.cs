namespace TabbedAppXamarin.Services.Images
{
    public interface ISaveImageService
    {
        void SaveImageLocally(byte[] bytes, int imageNumber);
        void SaveImageToGallery(string path);
        string ShowLocalFileName();
    }
}
