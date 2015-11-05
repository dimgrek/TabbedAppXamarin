using TabbedAppXamarin.ViewModels.Images;
using TabbedAppXamarin.Views.Images;
using Xamarin.Forms;
using XLabs;

namespace TabbedAppXamarin.Views
{
    public partial class ImageCollectionPage : ContentPage
    {
        private ImageCollectionViewModel _vm;

        public ImageCollectionPage()
        {
            InitializeComponent();
            _vm = new ImageCollectionViewModel();
            _vm.ItemSelected += OnItemSelected;
            BindingContext = _vm;
        }

        async void OnItemSelected(object sender, ImageSelectedEventArgs e)
        {
            await Navigation.PushAsync(new ImageViewPage(e.Source));

        }

        private void OnSelected(object sender, EventArgs<object> eventArgs)
        {
            if (_vm.OnSelectionCommand.CanExecute(eventArgs))
                _vm.OnSelectionCommand.Execute(eventArgs);
        }
    }
}
