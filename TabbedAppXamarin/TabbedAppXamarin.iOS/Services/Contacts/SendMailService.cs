using System;
using MessageUI;
using TabbedAppXamarin.iOS.Services.Contacts;
using TabbedAppXamarin.Services.Contacts;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SendMailService))]
namespace TabbedAppXamarin.iOS.Services.Contacts
{
    public class SendMailService : ISendMailService
    {
        public void ComposeMail(string[] recipients, string subject, string messagebody = null, Action<bool> completed = null)
        {
            var controller = new MFMailComposeViewController();
            controller.SetToRecipients(recipients);
            controller.SetSubject(subject);
            if (!string.IsNullOrEmpty(messagebody))
                controller.SetMessageBody(messagebody, false);
            controller.Finished += (object sender, MFComposeResultEventArgs e) => {
                if (completed != null)
                    completed(e.Result == MFMailComposeResult.Sent);
                e.Controller.DismissViewController(true, null);
            };

            //Adapt this to your app structure
            //var rootController = ((AppDelegate)(UIApplication.SharedApplication.Delegate)).Window.RootViewController.ChildViewControllers[0].ChildViewControllers[1].ChildViewControllers[0];
            //var navcontroller = rootController as UINavigationController;
            //if (navcontroller != null)
            //    rootController = navcontroller.VisibleViewController;
            //rootController.PresentViewController(controller, true, null);

            //var rootController = ((AppDelegate)(UIApplication.SharedApplication.Delegate)).Window.RootViewController.PresentedViewController;
            //var navcontroller = rootController as UINavigationController;
            //if (navcontroller != null)
            //    rootController = navcontroller.VisibleViewController;
            //rootController.PresentViewController(controller, true, null);


            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(controller, true, null);
        }
    }
}
