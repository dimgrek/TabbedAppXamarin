using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TabbedAppXamarin.Services.Images;
using Xamarin.Forms;
using XLabs;

namespace TabbedAppXamarin.ViewModels.Images
{
    public class ImageCollectionViewModel
    {
        private string _imagePath;
        private ImageService _is;
        private ImageViewModel _preloader;

        public ImageCollectionViewModel()
        {
            Images = new ObservableCollection<ImageViewModel>();
            RefreshCommand = new Command(AddImage);
            _is = new ImageService();
            _is.ImageDownloaded += AddImage;
            ShowPreloaders();
            OnSelectionCommand = new Command<EventArgs<object>>(OnSelection);
        }

        public ICommand RefreshCommand { get; private set; }
        public ICommand OnSelectionCommand { get; private set; }
        public ObservableCollection<ImageViewModel> Images { get; set; }

        private void AddImage()
        {
            Images.RemoveAt(0);
            Images.Add(new ImageViewModel(ImageSource.FromFile(_imagePath)));
        }


        private void AddImage(object sender, EventArgs e)
        {
            Images.RemoveAt(0);
            Images.Add(new ImageViewModel(ImageSource.FromFile(_imagePath)));
        }

        public event EventHandler<ImageSelectedEventArgs> ItemSelected;

        private async void ShowPreloaders()
        {
            //todo: scale to 50 images
            Images.Add(new ImageViewModel(ImageSource.FromFile("preloader.png")));
            _imagePath = await _is.SaveImage(0);
        }

        public void SaveImageToGallery(object sender, ImageSelectedEventArgs image)
        {
            _is.SaveImageToGallery(image.Source.ToString());
        }

        public void Remove(object sender, ImageSelectedEventArgs image)
        {
            Images.Remove(Images.Single(i => i.Source == image.Source));
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
            //todo: implement refresh logic properly
            ShowPreloaders();
        }
    }

    public class ImageSelectedEventArgs
    {
        public ImageSource Source { get; set; }
    }
}
