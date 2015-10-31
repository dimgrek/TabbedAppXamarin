using System.Collections.ObjectModel;
using Xamarin.Contacts;

namespace TabbedAppXamarin.Model
{
    public class ContactGroup : ObservableCollection<Contact>
    {
        public  ContactGroup(string firstName, Contact contact)
        {
            ShortName = firstName[0].ToString();
            All = new ObservableCollection<Contact>();
            All.Add(contact);
        }

        public string ShortName { get; set; }

        public ObservableCollection<Contact> All { private set; get; }
    }
}
