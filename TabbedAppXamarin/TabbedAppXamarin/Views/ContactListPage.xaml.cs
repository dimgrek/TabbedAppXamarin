using TabbedAppXamarin.ViewModels;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views
{
    public partial class ContactListPage : ContentPage
    {
        private ContactListViewModel _vm;

        public ContactListPage()
        {
            InitializeComponent();
            _vm = new ContactListViewModel();
            BindingContext = _vm;
            _vm.ItemSelected += OnItemSelected;
        }

        private void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (_vm.OnSelectionCommand.CanExecute(e))
                _vm.OnSelectionCommand.Execute(e);
        }

        async void OnItemSelected(object sender, ContactListViewModel.ItemSelectedEventArgs e)
        {
            await Navigation.PushAsync(new ContactViewPage(e.Id));
        }
    }
}
