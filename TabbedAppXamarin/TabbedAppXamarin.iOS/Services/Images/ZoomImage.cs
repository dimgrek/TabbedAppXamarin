using CoreGraphics;
using TabbedAppXamarin.Services.Images;
using UIKit;

namespace TabbedAppXamarin.iOS.Services.Images
{
    public class ZoomImage : IZoomImage
    {
        public void CreateImageView(double width, double height, string file)
        {
            var sv = new UIScrollView(
                new CGRect(0, 0, width, height));
            var imageView = new UIImageView(UIImage.FromFile(file));
            sv.ContentSize = imageView.Image.Size;
            sv.AddSubview(imageView);
            sv.MaximumZoomScale = 3f;
            sv.MinimumZoomScale = .1f;
            sv.ViewForZoomingInScrollView += (UIScrollView scrollView) => imageView;
        }
    }

   
}
