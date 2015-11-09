using System;
using TabbedAppXamarin.Services.Entities;
using TabbedAppXamarin.ViewModels;
using TabbedAppXamarin.ViewModels.Entities;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views
{
    public partial class EditEntityViewPage : ContentPage
    {
        private EntityListViewModel _entityListViewModel;

        public EditEntityViewPage(Guid id, EntityListViewModel entityListViewModel)
        {
            _entityListViewModel = entityListViewModel;
            InitializeComponent();
            var vm = new AddEntityViewModel(id, DependencyService.Get<IEntityService>());
            vm.ItemDeleted += OnBtnClicked;
            vm.ItemEdited += _entityListViewModel.OnItemEdited;
            vm.ItemSaved += OnBtnClicked;
            vm.ItemCanceled += OnBtnClicked;
            vm.WhatItemDeleted += _entityListViewModel.Delete;
            BindingContext = vm;
        }

        async void OnBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
