using System;
using CoreGraphics;
using FFImageLoading.Transformations;
using TabbedAppXamarin.Controls;
using TabbedAppXamarin.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomImage), typeof(NativeImageRenderer))]
namespace TabbedAppXamarin.iOS.Renderers
{
    public class NativeImageRenderer : ImageRenderer
    {
        private UIImage _image;
        private UIImageView _imageView;
        private FlipType flipType;

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                _image = UIImage.FromFile(e.NewElement.Source.ToString());
                _imageView = new UIImageView(new CGRect(50, 50, 100, 100));
                _imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
                _imageView.Image = _image;
                _imageView.Transform = CGAffineTransform.MakeRotation((float)Math.PI / 4);
                 AddSubview(_imageView);
                //FlipTransformation ft = new FlipTransformation(flipType);
                //var im = UIImage.FromFile(e.OldElement.Source.ToString());
                //ft.TransformFromUIImage(im);
            }
        }
    }
}
