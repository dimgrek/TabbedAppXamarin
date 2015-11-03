using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TabbedAppXamarin.Annotations;
using TabbedAppXamarin.Model;
using TabbedAppXamarin.Services.Entities;
using Xamarin.Forms;

namespace TabbedAppXamarin.ViewModels
{
    public class AddEntityViewModel:INotifyPropertyChanged
    {
        private string _description;
        private Guid _id;
        private bool _isActive;
        private SomeEntity _item;

        private Color _itemColor;
        private string _name;
        private IEntityService _service;


        public AddEntityViewModel(Guid id, IEntityService service)
        {
            _id = id;
            _service = service;
            _item = _service.GetThings().Single(x => x.Id == id);
            Name = _item.Name;
            Description = _item.Description;
            IsActive = _item.IsActive;
            EditCommand = new Command(Edit);
            DeleteCommand = new Command(Delete);
        }

        public AddEntityViewModel()
        {
            SaveCommand = new Command(Save);
            CancelCommand = new Command(Cancel);
            IsActive = false;
        }

        public DateTime Updated { get; set; }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; OnPropertyChanged();}
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged();}
        }

        public Guid Id { get; set; }

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged();}
        }

        public Color ItemColor
        {
            get { return _itemColor; }
            set { _itemColor = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void Cancel()
        {
            ItemCanceled?.Invoke(this, EventArgs.Empty);
        }

        private void Edit()
        {
            ItemEdited?.Invoke(this, new SomeEntityEventArgs { Entity = new SomeEntity
            {
                Id = _id,
                Name = Name,
                Description = Description,
                IsActive = IsActive,
                Updated = DateTime.Now
                //Color = IsActive ? Color.Transparent : Color.Gray
            } });
            ItemSaved?.Invoke(this, EventArgs.Empty);
        }

        private void Save()
        {
            ItemAdded?.Invoke(this, new SomeEntityEventArgs{ Entity = new SomeEntity
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Description = Description,
                IsActive = IsActive,
                Updated = DateTime.Now
                //Color = IsActive ? Color.Transparent : Color.Gray
            } });
            ItemSaved?.Invoke(this, EventArgs.Empty);
        }

        public void Delete()
        {
            _service.Delete(_item);
            WhatItemDeleted?.Invoke(this, new SomeEntityEventArgs { Entity = _item });
            ItemDeleted?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<SomeEntityEventArgs> ItemAdded;
        public event EventHandler<SomeEntityEventArgs> ItemEdited;
        public event EventHandler<SomeEntityEventArgs> WhatItemDeleted;
        public event EventHandler ItemSaved;
        public event EventHandler ItemCanceled;
        public event EventHandler ItemDeleted;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
