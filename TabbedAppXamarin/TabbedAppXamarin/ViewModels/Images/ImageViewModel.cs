using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace TabbedAppXamarin.ViewModels.Images
{
    public class ImageViewModel
    {
        public ImageViewModel(ImageSource source)
        {
            Source = source;
            EditCommand = new Command(EditImage);
            SaveCommand = new Command(SaveImage);
            RemoveCommand = new Command(RemoveImage);
        }


        public ImageSource Source { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        private void RemoveImage()
        {
            throw new NotImplementedException();
        }

        private void SaveImage()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<ImageSelectedEventArgs> EditPressed;

        private void EditImage()
        {
            EditPressed?.Invoke(this, new ImageSelectedEventArgs { Source = Source });
        }
    }
}