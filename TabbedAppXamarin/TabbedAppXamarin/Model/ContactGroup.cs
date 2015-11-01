using System.Collections.Generic;
using Xamarin.Contacts;

namespace TabbedAppXamarin.Model
{
    public class ContactGroup : List<Contact>
    {
        public  ContactGroup(string firstLetter)
        {
            ShortName = firstLetter;
        }

        public string ShortName { get; set; }

        public List<Contact> All { private set; get; }
    }
}
