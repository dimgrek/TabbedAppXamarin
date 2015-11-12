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

        public ImageCollectionViewModel()
        {
            Images = new ObservableCollection<ImageViewModel>();
            RefreshCommand = new Command(Refresh);
            _is = new ImageService();
            ShowPreloaders();
            OnSelectionCommand = new Command<EventArgs<object>>(OnSelection);
        }

        public ICommand RefreshCommand { get; private set; }
        public ICommand OnSelectionCommand { get; private set; }
        public ObservableCollection<ImageViewModel> Images { get; set; }
        public event EventHandler<ImageSelectedEventArgs> ItemSelected;

        private void AddImage(int imageNumber)
        {
            Images.RemoveAt(imageNumber);
            Images.Add(new ImageViewModel(ImageSource.FromFile(_imagePath)));
        }


        private async void ShowPreloaders()
        {
            for (var i = 0; i < 49; i++)
            {
                Images.Add(new ImageViewModel(ImageSource.FromFile("preloader.gif")));
                _imagePath = await _is.SaveImageLocally(i);
                AddImage(i);
            }
        }

        public void SaveImageToGallery(object sender, ImageSelectedEventArgs image)
        {
            _is.SaveImageToGallery(((FileImageSource)image.Source).File);
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
            Images.Clear();
            ShowPreloaders();
        }
    }
}
