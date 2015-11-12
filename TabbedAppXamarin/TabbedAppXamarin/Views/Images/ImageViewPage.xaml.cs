using TabbedAppXamarin.Controls;
using TabbedAppXamarin.Services.Images;
using TabbedAppXamarin.ViewModels.Images;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views.Images
{
    public partial class ImageViewPage : ContentPage
    {
        private ImageCollectionViewModel _icvm;
        private StackLayout _stack;
        private ImageViewModel _vm;

        public ImageViewPage(ImageSource source, ImageCollectionViewModel icvm)
        {
            _vm = new ImageViewModel(source);
            _icvm = icvm;
            _vm.EditPressed += OnEditPressed;
            BindingContext = _vm;
            _stack = new StackLayout {
                Padding = new Thickness(5, 0, 5, 0),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center };
            Content = _stack;
            InitializeComponent();
            ShowImage();
        }

        private void ShowImage()
        {
            var sv = new CustomScrollView();
            var image = new Image {Source = _vm.Source};
            var btn = new Button
            {
                Text = "Edit",
                Command = new Command(() => { _vm.EditImage(); })
            };
            sv.Content = image;

            _stack.Children.Add(sv);
            _stack.Children.Add(btn);
        }

        async void OnEditPressed(object sender, ImageSelectedEventArgs e)
        {
            await Navigation.PushAsync(new EditImageViewPage(e.Source, _icvm));
        }
    }
}
