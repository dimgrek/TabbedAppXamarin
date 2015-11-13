using System;
using System.Drawing;
using CoreGraphics;
using TabbedAppXamarin.Controls;
using TabbedAppXamarin.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomScrollView), typeof(NativeScrollViewRenderer))]

namespace TabbedAppXamarin.iOS.Renderers
{
    public class NativeScrollViewRenderer : ScrollViewRenderer
    {
        private nfloat dx = 0;
        private nfloat dy = 0;
        private UIImageView imageView;
        private UIPanGestureRecognizer panGesture;
        private UIPinchGestureRecognizer pinchGesture;
        private nfloat r = 0;
        private UIRotationGestureRecognizer rotateGesture;


        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                CreateRotationGestureRecognizer();
                CreatePanGestureRecognizer();
                CreatePinchGestureRecognizer();
                Subviews[0].AddGestureRecognizer(panGesture);
                Subviews[0].AddGestureRecognizer(rotateGesture);
                Subviews[0].AddGestureRecognizer(pinchGesture);
            }
        }

        private void CreatePinchGestureRecognizer()
        {
            pinchGesture = new UIPinchGestureRecognizer(() =>
            {

                if ((pinchGesture.State == UIGestureRecognizerState.Began ||
                     pinchGesture.State == UIGestureRecognizerState.Changed) && (pinchGesture.NumberOfTouches == 2))
                {
                    pinchGesture.View.Transform *= CGAffineTransform.MakeScale(pinchGesture.Scale, pinchGesture.Scale);
                    pinchGesture.Scale = 1;
                }
             });
        }

        private void CreatePanGestureRecognizer()
        {
            panGesture = new UIPanGestureRecognizer(() =>
            {
                if ((panGesture.State == UIGestureRecognizerState.Began || panGesture.State == UIGestureRecognizerState.Changed) && (panGesture.NumberOfTouches == 1))
                {

                    var p0 = panGesture.LocationInView(this);

                    if (dx == 0)
                        dx = p0.X - Subviews[0].Center.X;

                    if (dy == 0)
                        dy = p0.Y - Subviews[0].Center.Y;

                    var p1 = new PointF((float)(p0.X - dx), (float)(p0.Y - dy));

                    Subviews[0].Center = p1;
                }
                else if (panGesture.State == UIGestureRecognizerState.Ended)
                {
                    dx = 0;
                    dy = 0;
                }
            });
        }

        private void CreateRotationGestureRecognizer()
        {
            rotateGesture = new UIRotationGestureRecognizer(() =>
            {
                if ((rotateGesture.State == UIGestureRecognizerState.Began ||
                rotateGesture.State == UIGestureRecognizerState.Changed) && (rotateGesture.NumberOfTouches == 2))
                {
                    Transform = CGAffineTransform.MakeRotation(rotateGesture.Rotation + r);
                }
                else if (rotateGesture.State == UIGestureRecognizerState.Ended)
                {
                    r += rotateGesture.Rotation;
                }
            });
        }
    }
}

        
