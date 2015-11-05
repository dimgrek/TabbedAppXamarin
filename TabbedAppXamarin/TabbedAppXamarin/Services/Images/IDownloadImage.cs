namespace TabbedAppXamarin.Services.Images
{
    public interface IDownloadImage
    {
        void SaveImage(byte[] bytes, int imageNumber);
        string ShowLocalFileName();
    }
}
