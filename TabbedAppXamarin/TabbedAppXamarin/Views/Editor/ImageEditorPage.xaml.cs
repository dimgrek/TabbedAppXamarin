using System;
using TabbedAppXamarin.ViewModels.Editor;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views
{
    public partial class ImageEditorPage : ContentPage
    {
        
        private ImageEditorViewModel _vm;


        public ImageEditorPage()
        {
            _vm = new ImageEditorViewModel();
            BindingContext = _vm;
            _vm.RotateTheImage += RotateImage;
            InitializeComponent();
        }

        public async void RotateImage(object sender, EventArgs args)
        {
            await image.RotateTo(270, 0);
        }
    }
}
