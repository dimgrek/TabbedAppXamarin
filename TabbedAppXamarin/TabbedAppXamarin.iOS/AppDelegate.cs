using Foundation;
using TabbedAppXamarin.iOS.Services.Contacts;
using TabbedAppXamarin.iOS.Services.Images;
using TabbedAppXamarin.Services.Entities;
using UIKit;
using Xamarin.Forms;
using XLabs.Forms;

namespace TabbedAppXamarin.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : XFormsApplicationDelegate
    {
        private UIWindow window;

        public UIWindow Window
        {
            get { return window; }
        }

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            DependencyService.Register<EntityService>();
            DependencyService.Register<SaveImageService>();
            DependencyService.Register<ZoomImage>();
            DependencyService.Register<DialNumberService>();
            DependencyService.Register<SendMailService>();
            Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
