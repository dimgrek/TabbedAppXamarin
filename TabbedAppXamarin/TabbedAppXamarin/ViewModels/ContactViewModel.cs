using System;
using System.Linq;
using Contacts.Plugin.Abstractions;

namespace TabbedAppXamarin.ViewModels
{
    public class ContactViewModel
    {
        private readonly Contact _contact;

        public ContactViewModel(Contact contact)
        {
            _contact = contact;
        }

        public string Forename { get { return _contact.FirstName; } }

        public string Surname
        {
            get { return _contact.LastName ?? _contact.FirstName; }
        }

        public string Name { get { return _contact.DisplayName; } }

        public string PhoneNumber
        {
            get { return _contact.Phones.First(p => p.Label == "Mobile").Number; }
        }

        public string SortByCharacter
        {
            get
            {
                var str = _contact.LastName ?? _contact.FirstName;

                if (string.IsNullOrEmpty(str))
                    throw new Exception("The contact has no first or last name");

                return str[0].ToString().ToUpper();
            }
        }

        public object Contact { get { return _contact; } }
    }

    public class PhoneEventArgs
    {
        public string Phone { get; set; }
    }
}
