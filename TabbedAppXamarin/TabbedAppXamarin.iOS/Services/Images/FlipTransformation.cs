using System;
using FFImageLoading.Transformations;
using UIKit;

namespace TabbedAppXamarin.iOS.Services.Images
{
    public class FlipTransformation : TransformationBase
    {
        private FlipType _flipType;

        public FlipTransformation(FlipType flipType)
        {
            _flipType = flipType;
        }

        public override string Key => "FlipTransformation, Type=";

        protected override UIImage Transform(UIImage source)
        {
            switch (_flipType)
            {
                case FlipType.Vertical:
                    return new UIImage(source.CGImage, source.CurrentScale, UIImageOrientation.DownMirrored);

                case FlipType.Horizontal:
                    return new UIImage(source.CGImage, source.CurrentScale, UIImageOrientation.UpMirrored);

                default:
                    throw new Exception("Invalid FlipType");
            }
        }

        public UIImage TransformFromFile(string file)
        {
            var source = UIImage.FromFile(file);
            switch (_flipType)
            {
                case FlipType.Vertical:
                    return new UIImage(source.CGImage, source.CurrentScale, UIImageOrientation.DownMirrored);

                case FlipType.Horizontal:
                    return new UIImage(source.CGImage, source.CurrentScale, UIImageOrientation.UpMirrored);

                default:
                    throw new Exception("Invalid FlipType");
            }
        }
        public UIImage TransformFromUIImage(UIImage source)
        {
            switch (_flipType)
            {
                case FlipType.Vertical:
                    return new UIImage(source.CGImage, source.CurrentScale, UIImageOrientation.DownMirrored);

                case FlipType.Horizontal:
                    return new UIImage(source.CGImage, source.CurrentScale, UIImageOrientation.UpMirrored);

                default:
                    throw new Exception("Invalid FlipType");
            }
        }
    }
}
