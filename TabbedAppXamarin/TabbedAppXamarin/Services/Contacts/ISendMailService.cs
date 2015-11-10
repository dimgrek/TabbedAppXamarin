using System;

namespace TabbedAppXamarin.Services.Contacts
{
    public interface ISendMailService
    {
        void ComposeMail(string[] recipients, string subject, string messagebody = null, Action<bool> completed = null);
    }
}
