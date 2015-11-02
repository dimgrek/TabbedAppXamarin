using System;
using TabbedAppXamarin.ViewModels;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views
{
    public partial class ContactViewPage : ContentPage
    {
        private ContactViewModel _cvm;
        private StackLayout _stack;

        public ContactViewPage(ContactViewModel cvm)
        {
            _cvm = cvm;
            _stack = new StackLayout { Padding = new Thickness(5, 0, 5, 0) };
            
            Content = _stack;
            ShowPhones();
            ShowEmails();
            InitializeComponent();
        }

        private void ShowPhones()
        {
            _stack.Children.Add(new Label { Text = "Telephones:" });
            foreach (var telephone in _cvm.PhoneNumbers)
            {
                _stack.Children.Add(new Label
                {
                    Text = telephone.Number
                });
            }
        }

        private void ShowEmails()
        {
            _stack.Children.Add(new Label { Text = "Emails:" });
            foreach (var email in _cvm.Emails)
            {
                _stack.Children.Add(new Label
                {
                    Text = email.Address
                });
            }
        }

        async void OnBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
