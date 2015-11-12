using TabbedAppXamarin.ViewModels.Images;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views.Images
{
    public partial class ImageViewPage : ContentPage
    {
        private readonly ImageCollectionViewModel _icvm;

        public ImageViewPage(ImageSource source, ImageCollectionViewModel icvm)
        {
            var vm = new ImageViewModel(source);
            _icvm = icvm;
            vm.EditPressed += OnEditPressed;
            BindingContext = vm;
            InitializeComponent();
        }

        async void OnEditPressed(object sender, ImageSelectedEventArgs e)
        {
            await Navigation.PushAsync(new EditImageViewPage(e.Source, _icvm));
        }
    }
}
