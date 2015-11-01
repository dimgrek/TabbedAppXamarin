using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Contacts.Plugin;
using Contacts.Plugin.Abstractions;
using Xamarin.Forms;

namespace TabbedAppXamarin.ViewModels

{
    public class ContactListViewModel
    {
        private ObservableCollection<Grouping<string, ContactViewModel>> _contacts;
        private ObservableCollection<Grouping<string, ContactViewModel>> _filteredContacts;
        private string _text;


        public ContactListViewModel()
        {
            SearchTextChanged = new Command<string>(s => FilterContacts(s));
            OnSelectionCommand = new Command<SelectedItemChangedEventArgs>(OnSelection);
            _contacts = new ObservableCollection<Grouping<string, ContactViewModel>>();
            _filteredContacts = new ObservableCollection<Grouping<string, ContactViewModel>>();
            CrossContacts.Current.PreferContactAggregation = false;
            var hasPermission = CrossContacts.Current.RequestPermission().Result;

            if (hasPermission)
            {
                //var vms = CrossContacts.Current.Contacts.Where(c => Matches(c))
                    //.Select(c => new ContactViewModel(c));

                var vms = CrossContacts.Current.Contacts.Select(c => new ContactViewModel(c));

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
            }
        }

        public ICommand SearchTextChanged { get; private set; }
        public ICommand SearchContactCommand { get; private set; }
        public ICommand OnSelectionCommand { get; private set; }

        public ObservableCollection<Grouping<string, ContactViewModel>> FilteredContacts
        {
            get { return _filteredContacts; }
        }

        public ObservableCollection<Grouping<string, ContactViewModel>> Contacts
        {
            get { return _contacts; }
        }

        public event EventHandler<ItemSelectedEventArgs> ItemSelected;

        private bool Matches(Contact contact)
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
            var contactItem = e.SelectedItem as ContactViewModel;
            ItemSelected?.Invoke(this, new ItemSelectedEventArgs { cvm = contactItem });
        }

        public class ItemSelectedEventArgs
        {
            public ContactViewModel cvm { get; set; }
        }
    }
}

       

