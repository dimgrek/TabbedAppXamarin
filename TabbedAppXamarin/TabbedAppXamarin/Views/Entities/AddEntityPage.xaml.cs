using System;
using TabbedAppXamarin.ViewModels;
using TabbedAppXamarin.ViewModels.Entities;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views.Entities
{
    public partial class AddEntityPage : ContentPage
    {
        private readonly EntityListViewModel _entityListViewModel;

        public AddEntityPage(EntityListViewModel entityListViewModel)
        {
            InitializeComponent();
            _entityListViewModel = entityListViewModel;
            var vm = new AddEntityViewModel();
            vm.ItemAdded += _entityListViewModel.OnNewItemAdded;
            vm.ItemSaved += OnBtnClicked;
            vm.ItemCanceled += OnBtnClicked;
            vm.ItemDeleted += OnBtnClicked;
            BindingContext = vm;
        }

        async void OnBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
