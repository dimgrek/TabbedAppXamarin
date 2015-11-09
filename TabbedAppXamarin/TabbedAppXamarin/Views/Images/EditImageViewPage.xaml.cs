using TabbedAppXamarin.ViewModels.Images;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views.Images
{
    public partial class EditImageViewPage : ContentPage
    {
        private ImageCollectionViewModel _icvm;
        private ImageViewModel _vm;

        public EditImageViewPage(ImageSource source, ImageCollectionViewModel icvm)
        {
            InitializeComponent();
            _icvm = icvm;
            _vm = new ImageViewModel(source);
            _vm.RemovePressed += GoBack;
            _vm.RemovePressed += _icvm.Remove;
            _vm.SavePressed += GoBack;
            _vm.SavePressed += _icvm.SaveImageToGallery;
            BindingContext = _vm;
        }

        async void GoBack(object sender, ImageSelectedEventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
