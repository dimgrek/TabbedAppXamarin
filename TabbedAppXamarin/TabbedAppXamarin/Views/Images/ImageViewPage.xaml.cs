using TabbedAppXamarin.ViewModels.Images;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views.Images
{
    public partial class ImageViewPage : ContentPage
    {
        private ImageCollectionViewModel _icvm;
        private ImageViewModel _vm;

        public ImageViewPage(ImageSource source, ImageCollectionViewModel icvm)
        {
            InitializeComponent();
            _vm = new ImageViewModel(source);
            _icvm = icvm;
            _vm.EditPressed += OnEditPressed;
            BindingContext = _vm;
        }

        async void OnEditPressed(object sender, ImageSelectedEventArgs e)
        {
            await Navigation.PushAsync(new EditImageViewPage(e.Source, _icvm));
        }
    }
}
