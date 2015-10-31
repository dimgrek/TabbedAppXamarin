using System;
using System.Linq;
using Xamarin.Contacts;

namespace TabbedAppXamarin.ViewModels
{
    public class ContactViewModel
    {
        private AddressBook _book;
        private Contact _contact;

        public ContactViewModel(string id)
        {
            _book = new AddressBook();
            _contact = _book.FirstOrDefault(c => c.Id == id);
            SetView();
        }

        public event EventHandler<PhoneEventArgs> PhoneAdded;

        private void SetView()
        {
            //foreach (var phone in _contact.Phones)
            //{
            //}   
                PhoneAdded?.Invoke(this, new PhoneEventArgs {Phone = "34234324"});
        }
    }

    public class PhoneEventArgs
    {
        public string Phone { get; set; }
    }
}
