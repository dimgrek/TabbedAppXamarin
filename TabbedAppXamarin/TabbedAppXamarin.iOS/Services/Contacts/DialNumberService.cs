using System;
using Foundation;
using MessageUI;
using TabbedAppXamarin.Services.Contacts;
using UIKit;

namespace TabbedAppXamarin.iOS.Services.Contacts
{
    public class DialNumberService : IDialNumberService
    {
        public void DialNumber(string number)
        {
              var url = new NSUrl("tel:" + number);
            UIApplication.SharedApplication.OpenUrl(url);
            if (!UIApplication.SharedApplication.OpenUrl(url))
            {
                var av = new UIAlertView("Not supported",
                  "Scheme 'tel:' is not supported on this device",
                  null,
                  "OK",
                  null);
                av.Show();
            };
        }

    }
}
