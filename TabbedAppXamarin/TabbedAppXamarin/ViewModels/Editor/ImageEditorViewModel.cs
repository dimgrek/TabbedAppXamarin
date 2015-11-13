using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FFImageLoading.Transformations;
using TabbedAppXamarin.Annotations;
using TabbedAppXamarin.Services.Images;
using Xamarin.Forms;

namespace TabbedAppXamarin.ViewModels.Editor
{
    public class ImageEditorViewModel: INotifyPropertyChanged
    {
        private string _imagePath;
        private ImageService _is;
        private ImageSource _source;
        private ImageSource _source1;

        public ImageEditorViewModel()
        {
            RotateCommand = new Command(Rotate);
            FlipHorCommand = new Command(FlipHorizontally);
            FlipVertCommand = new Command(FlipVertically);
            _is = new ImageService();
            ShowImage();
        }

        public ImageSource Source
        {
            get { return _source; }
            set
            {
                _source = value;
                OnPropertyChanged();
            }
        }

        public ImageSource Source1
        {
            get { return _source1; }
            set
            {
                _source1 = value;
                OnPropertyChanged();
            }
        }

        public ICommand RotateCommand { get; private set; }
        public ICommand FlipHorCommand { get; private set; }
        public ICommand FlipVertCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ShowImage()
        {
            Source = ImageSource.FromFile("SampleImage.jpeg");
        }

        public event EventHandler<EventArgs> RotateTheImage;

        private void FlipVertically()
        {
            Stream stream = new MemoryStream(_is.FlipImage(FlipType.Vertical, "SampleImage.jpeg"));
            Source = ImageSource.FromStream(() => stream);
        }

        private void FlipHorizontally()
        {
            Stream stream = new MemoryStream(_is.FlipImage(FlipType.Horizontal, "SampleImage.jpeg"));
            Source = ImageSource.FromStream(() => stream);
       }

        public void Rotate()
        {
            RotateTheImage?.Invoke(this, EventArgs.Empty);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
