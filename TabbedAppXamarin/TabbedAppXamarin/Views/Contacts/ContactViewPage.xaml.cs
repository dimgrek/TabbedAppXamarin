using TabbedAppXamarin.Services.Contacts;
using TabbedAppXamarin.ViewModels;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views
{
    public partial class ContactViewPage : ContentPage
    {
        private readonly ContactViewModel _cvm;
        private readonly IDialNumberService _ds;
        private readonly StackLayout _stack;

        public ContactViewPage(ContactViewModel cvm)
        {
            _cvm = cvm;
            _ds = DependencyService.Get<IDialNumberService>();
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
                var grid = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition {Height = GridLength.Auto}
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition {Width = GridLength.Auto},
                        new ColumnDefinition {Width = GridLength.Auto}
                    }
                };

                var label = new Label
                {
                    Text = telephone.Number,
                    VerticalOptions = LayoutOptions.Center
                };
                grid.Children.Add(label, 0, 0);

                var dialBtn = new Button
                {
                    Text = "Dial",
                    Command = new Command(() => { _ds.DialNumber(label.Text); })
                };
                grid.Children.Add(dialBtn, 1, 0);
                _stack.Children.Add(grid);
            }
        }

        private void ShowEmails()
        {
            _stack.Children.Add(new Label { Text = "Emails:" });
            foreach (var email in _cvm.Emails)
            {
                var grid = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition {Height = GridLength.Auto}
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition {Width = GridLength.Auto},
                        new ColumnDefinition {Width = GridLength.Auto}
                    }
                };

                var label = new Label
                {
                    Text = email.Address,
                    VerticalOptions = LayoutOptions.Center
                };
                grid.Children.Add(label, 0, 0);

                var sendBtn = new Button
                {
                    Text = "Send an email"
                };
                sendBtn.Command = new Command(() =>
                {
                    var mailservice = DependencyService.Get<ISendMailService>();
                    if (mailservice == null)
                        return;
                    mailservice.ComposeMail(new[] {email.Address}, "Hello "+_cvm.Name, "Dear "+ _cvm.Name);
                });
                grid.Children.Add(sendBtn, 1, 0);
                _stack.Children.Add(grid);
            }
        }
    }
}
