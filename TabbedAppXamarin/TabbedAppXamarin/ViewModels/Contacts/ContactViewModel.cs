using System;
using System.Collections.Generic;
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

        public List<Organization> Organizations => _contact.Organizations;

        public string Forename => _contact.FirstName;

        public string Surname => _contact.LastName ?? _contact.FirstName;

        public string Name => _contact.DisplayName;

        public List<Phone> PhoneNumbers => _contact.Phones;

        public List<Email> Emails => _contact.Emails;

        public string SortByCharacter
        {
            get
            {
                var str = _contact.LastName ?? _contact.FirstName;

                if (string.IsNullOrEmpty(str))
                    new Exception("Contact contains neither last name nor first name");

                return str[0].ToString().ToUpper();
            }
        }

        public object Contact => _contact;
    }
}
