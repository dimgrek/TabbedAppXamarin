﻿using System;
using TabbedAppXamarin.Services.Entities;
using TabbedAppXamarin.ViewModels;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views
{
    public partial class EntityListPage : ContentPage
    {
        private EntityListViewModel _vm;

        public EntityListPage()
        {
            _vm = new EntityListViewModel(DependencyService.Get<IEntityService>());
            BindingContext = _vm;
            _vm.AddItemClicked += OnAddBtnClicked;
            _vm.ItemSelected += OnItemSelected;
            InitializeComponent();
        }


        async void OnItemSelected(object sender, EntitySelectedEventArgs e)
        { 
           await Navigation.PushAsync(new EditEntityViewPage(e.Id, _vm));
        }

        async void OnAddBtnClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new AddEntityPage(_vm));
        }

        private void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (_vm.OnSelectionCommand.CanExecute(e))
                _vm.OnSelectionCommand.Execute(e);
        }

        //    if (_vm.DeleteCommand.CanExecute(args))
        //    var args = new SelectedItemChangedEventArgs(item);
        //    var item = ((MenuItem)sender).CommandParameter as ContactItem;
        //{

        //private void OnDelete(object sender, EventArgs e)
        //        _vm.DeleteCommand.Execute(args);
        //}
    }
}
