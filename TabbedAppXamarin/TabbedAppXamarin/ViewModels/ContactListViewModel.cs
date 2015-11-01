using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Contacts.Plugin;
using Xamarin.Forms;

namespace TabbedAppXamarin.ViewModels

{
    public class ContactListViewModel
    {
        //private AddressBook _book;
        private ObservableCollection<Grouping<string, ContactViewModel>> _contacts;
        private ObservableCollection<Grouping<string, ContactViewModel>> _filteredContacts;
        private string _text;


        public ContactListViewModel()
        {
            //_book = new AddressBook();
            //GroupContactsList = new ObservableCollection<Contact>();
            //FilteredContactsList = new ObservableCollection<Contact>();
            //SearchContactCommand = new Command(SearchContact);
            //OnSelectionCommand = new Command<SelectedItemChangedEventArgs>(OnSelection);
            //ContactList = new List<Contact>();

            SearchTextChanged = new Command<string>(s => FilterContacts(s));
            _contacts = new ObservableCollection<Grouping<string, ContactViewModel>>();
            _filteredContacts = new ObservableCollection<Grouping<string, ContactViewModel>>();
            CrossContacts.Current.PreferContactAggregation = false;
            var hasPermission = CrossContacts.Current.RequestPermission().Result;

            if (hasPermission)
            {
                // First off convert all contacts into ContactViewModels...
                var vms = CrossContacts.Current.Contacts.Where(c => Matches(c))
                    .Select(c => new ContactViewModel(c));

                // And then setup the contact list
                var grouped = from contact in vms
                    orderby contact.Surname
                    group contact by contact.SortByCharacter
                    into contactGroup
                    select new Grouping<string, ContactViewModel>(contactGroup.Key, contactGroup);

                foreach (var g in grouped)
                {
                    _contacts.Add(g);
                    _filteredContacts.Add(g);
                }
                //ShowContacts();
            }
        }

        public ICommand SearchTextChanged { get; private set; }
        public ICommand OnSelectionCommand { get; private set; }
        public ICommand SearchContactCommand { get; private set; }

        //public string Text
        //{
        //    get { return _text; }
        //    set
        //    {
        //        _text = value;
        //        OnPropertyChanged();
        //    }
        //}

        public ObservableCollection<Grouping<string, ContactViewModel>> FilteredContacts
        {
            get { return _filteredContacts; }
        }

        public ObservableCollection<Grouping<string, ContactViewModel>> Contacts
        {
            get { return _contacts; }
        }

        //public ObservableCollection<Contact> GroupContactsList { get; set; }
        //public ObservableCollection<Contact> FilteredContactsList { get; set; }
        //public List<Contact> ContactList { get; set; }


        public event EventHandler<ItemSelectedEventArgs> ItemSelected;

        private bool Matches(Contacts.Plugin.Abstractions.Contact contact)
        {
            var matches = false;

            if ((contact.FirstName != null) || (contact.LastName != null))
            {
                matches = contact.Phones.Any(p => p.Label == "Mobile");
            }

            return matches;
        }

        public void FilterContacts(string filter)
        {
            _filteredContacts.Clear();

            if (string.IsNullOrEmpty(filter))
            {
                foreach (var g in Contacts)
                    _filteredContacts.Add(g);
            }
            else
            {
                // Need to do some filtering
                foreach (var g in Contacts)
                {
                    var matches = g.Where(vm => vm.Name.Contains(filter));

                    if (matches.Any())
                    {
                        _filteredContacts.Add(new Grouping<string, ContactViewModel>(g.Key, matches));
                    }
                }
            }
        }

        private void OnSelection(SelectedItemChangedEventArgs e)
        {
            //var contactItem = e.SelectedItem as Contact;
            //if (contactItem == null)
            //    return;
            //ItemSelected?.Invoke(this, new ItemSelectedEventArgs {Id = contactItem.Suffix});
        }


        //private void SearchContact()
        //{
        //    var result = GroupContactsList.FirstOrDefault(c => c.FirstName == Text);
        //    GroupContactsList.Clear();
        //    GroupContactsList.Add(result);
        //    //todo: don't clear all contacts, add support to cancel btn;

        //    //}


        //private void ShowContacts()
        //{
        //    _book.RequestPermission().ContinueWith(t =>
        //    {
        //        if (!t.Result)
        //        {
        //            //Console.WriteLine("Permission denied by user or manifest");
        //        }


        //        foreach (var contact in _book.OrderBy(c => c.LastName))
        //        {
        //            GroupContactsList.Add(new Contact
        //            {
        //                Emails = contact.Emails,
        //                FirstName = contact.FirstName,
        //                LastName = contact.LastName,
        //                Suffix = contact.Id
        //            });
        //            FilteredContactsList.Add(new Contact
        //            {
        //                Emails = contact.Emails,
        //                FirstName = contact.FirstName,
        //                LastName = contact.LastName,
        //                Suffix = contact.Id
        //            });
        //        }


        //    }, TaskScheduler.FromCurrentSynchronizationContext());

        //var group = _book.GroupBy(c => string.IsNullOrEmpty(c.LastName) ? " " : c.LastName[0].ToString())
        //                 .Select(g => new ContactGroup(g.Key.ToString()).AddRange(g));

        //GroupContactsList.Add(new ContactGroup(ContactList[0].FirstName, ContactList[0]));
        //todo: alphabetic right-side bar
        //}

        public class ItemSelectedEventArgs
        {
            public string Id { get; set; }
        }
    }
}

       

