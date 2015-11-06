using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TabbedAppXamarin.Services.Images;
using Xamarin.Forms;
using XLabs;

namespace TabbedAppXamarin.ViewModels.Images
{
    public class ImageCollectionViewModel
    {
        private ImageService _is;

        public ImageCollectionViewModel()
        {
            Images = new ObservableCollection<ImageViewModel>();
            RefreshCommand = new Command(Refresh);
            _is = new ImageService();
            ShowImages();
            OnSelectionCommand = new Command<EventArgs<object>>(OnSelection);
        }

        public ICommand RefreshCommand { get; private set; }
        public ICommand OnSelectionCommand { get; private set; }
        public ObservableCollection<ImageViewModel> Images { get; set; }
        public event EventHandler<ImageSelectedEventArgs> ItemSelected;

        private async void ShowImages()
        {
            await _is.SaveImage(1);
            //var imagePath = _is.ShowPath();
            Images.Add(new ImageViewModel(ImageSource.FromFile(_is.ShowPath())));
            //var image = await _is.ReturnResponce();
            //var image = "http://lorempixel.com/400/400/";
            //Images.Add(new ImageViewModel());
            //Images.Add(new ImageViewModel());
            //Images.Add(new ImageViewModel());
            //Images.Add(new ImageViewModel(new UriImageSource {CachingEnabled = false, Uri = new Uri(image)}));
            //Images.Add(new ImageViewModel(new UriImageSource {CachingEnabled = false, Uri = new Uri(image)}));
            //Images.Add(new ImageViewModel(new UriImageSource {CachingEnabled = false, Uri = new Uri(image)}));

        }

        private void OnSelection(EventArgs<object> eventArgs)
        {
            var image = eventArgs.Value as ImageViewModel;
            if (image == null)
                return;
            ItemSelected?.Invoke(this, new ImageSelectedEventArgs { Source = image.Source });
        }

        private void Refresh()
        {
            throw new NotImplementedException();
        }
    }

    public class ImageSelectedEventArgs
    {
        public ImageSource Source { get; set; }
    }
}
