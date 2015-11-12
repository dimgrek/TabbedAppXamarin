using Xamarin.Forms;

namespace TabbedAppXamarin.Services.Images
{
    public interface IZoomImage
    {
        void CreateImageView(double width, double height, string file);
    }
}
