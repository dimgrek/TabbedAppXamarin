using System;
using TabbedAppXamarin.ViewModels.Entities;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views
{
    public partial class EntityListPage : ContentPage
    {
        private readonly EntityListViewModel _vm;

        public EntityListPage()
        {
            _vm = new EntityListViewModel();
            BindingContext = _vm;
            _vm.AddItemClicked += OnAddBtnClicked;
            _vm.ItemSelected += OnItemSelected;
            InitializeComponent();
        }


        async void OnItemSelected(object sender, EntitySelectedEventArgs e)
        {
            if (!e.IsNewItem)
                await Navigation.PushAsync(new EditEntityViewPage(e.Id, _vm));
            
        }

        async void OnAddBtnClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Entities.AddEntityPage(_vm));
        }

        private void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (_vm.OnSelectionCommand.CanExecute(e))
                _vm.OnSelectionCommand.Execute(e);
        }
    }
}
