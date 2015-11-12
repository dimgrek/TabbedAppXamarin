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
            //EditCommand = new Command(EditImage);
            SaveCommand = new Command(SaveImage);
            RemoveCommand = new Command(RemoveImage);
        }

        public ImageSource Source { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        private void RemoveImage()
        {
            RemovePressed?.Invoke(this, new ImageSelectedEventArgs { Source = Source });
        }

        private void SaveImage()
        {
            SavePressed?.Invoke(this, new ImageSelectedEventArgs { Source = Source });
        }

        public event EventHandler<ImageSelectedEventArgs> EditPressed;
        public event EventHandler<ImageSelectedEventArgs> RemovePressed;
        public event EventHandler<ImageSelectedEventArgs> SavePressed;

        public void EditImage()
        {
            EditPressed?.Invoke(this, new ImageSelectedEventArgs { Source = Source });
        }
    }
}