using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using TabbedAppXamarin.Annotations;
using Xamarin.Contacts;
using Xamarin.Forms;

namespace TabbedAppXamarin.ViewModels

{
    public class ContactListViewModel : INotifyPropertyChanged
    {
        private AddressBook _book;
        private string _text;


        public ContactListViewModel()
        {
            _book = new AddressBook();
            GroupContactsList = new ObservableCollection<Contact>();
            SearchContactCommand = new Command(SearchContact);
            OnSelectionCommand = new Command<SelectedItemChangedEventArgs>(OnSelection);
            ContactList = new List<Contact>();

            ShowContacts();
        }

        public ICommand OnSelectionCommand { get; private set; }
        public ICommand SearchContactCommand { get; private set; }

        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(); }
        }


        public ObservableCollection<Contact> GroupContactsList { get; set; }
        public List<Contact> ContactList { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<ItemSelectedEventArgs> ItemSelected;

        private void OnSelection(SelectedItemChangedEventArgs e)
        {
            var contactItem = e.SelectedItem as Contact;
            if (contactItem == null)
                return;
            ItemSelected?.Invoke(this, new ItemSelectedEventArgs { Id = contactItem.Suffix });
        }


        private void SearchContact()
        {
            var result = GroupContactsList.FirstOrDefault(c => c.FirstName == Text);
            GroupContactsList.Clear();
            GroupContactsList.Add(result);
            //todo: don't clear all contacts, add support to cancel btn;
            
        }


        private void ShowContacts()
        {
            _book.RequestPermission().ContinueWith(t =>
            {
                if (!t.Result)
                {
                    //Console.WriteLine("Permission denied by user or manifest");
                    return;
                }

                foreach (var contact in _book.OrderBy(c => c.LastName))
                {
                    GroupContactsList.Add(new Contact
                    {
                        Emails = contact.Emails,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Suffix = contact.Id
                     });
                }
            }, TaskScheduler.FromCurrentSynchronizationContext ());

            //GroupContactsList.Add(new ContactGroup(ContactList[0].FirstName, ContactList[0]));
            //todo: alphabetic right-side bar
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class ItemSelectedEventArgs
        {
            public string Id { get; set; }
        }
    }
}

