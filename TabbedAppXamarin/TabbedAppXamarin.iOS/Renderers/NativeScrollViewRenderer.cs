using System;
using System.Collections.Generic;
using System.Text;
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
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                this.MaximumZoomScale = 4f;
                this.MinimumZoomScale = 0.5f;
                this.ViewForZoomingInScrollView += (UIScrollView sv) => { return this.Subviews[0]; };
            }
        }
    }
}
