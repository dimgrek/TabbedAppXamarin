using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TabbedAppXamarin.Annotations;
using TabbedAppXamarin.Model;
using TabbedAppXamarin.Services.Entities;
using TabbedAppXamarin.Views.Entities;
using Xamarin.Forms;

namespace TabbedAppXamarin.ViewModels.Entities
{
    public class EntityListViewModel:INotifyPropertyChanged
    {
        private readonly EntityService _service;
        private bool _itemAdded;
        private EntityViewModel _selectedItem;

        public EntityListViewModel()
        {
            _service = DependencyService.Get<EntityService>();
            Items = new ObservableCollection<EntityViewModel>(_service.
                GetThingsOrdered().
                Select(x=>new EntityViewModel(x)));
            AddCommand = new Command(Add);
            OnSelectionCommand = new Command<SelectedItemChangedEventArgs>(OnSelection);
        }

        public ObservableCollection<EntityViewModel> Items { get; set; }

        public EntityViewModel SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; OnPropertyChanged();}
        }

        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand OnSelectionCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler AddItemClicked;
        public event EventHandler<EntitySelectedEventArgs> ItemSelected;

        private void Add()
        {
            AddItemClicked?.Invoke(this, EventArgs.Empty);
        }

        public void Delete(object sender, SomeEntityEventArgs entity)
        {
            Items.Remove(Items.Single(o => o.Id == entity.Entity.Id));
        }

        private void OnSelection(SelectedItemChangedEventArgs e)
        {
            var entity = e.SelectedItem as EntityViewModel;
            if (entity == null)
                return;
            ItemSelected?.Invoke(this,
                _itemAdded
                    ? new EntitySelectedEventArgs {Id = entity.Id, IsNewItem = true}
                    : new EntitySelectedEventArgs {Id = entity.Id, IsNewItem = false});
        }

        public void OnNewItemAdded(object sender, SomeEntityEventArgs e)
        {
            var entityVM = new EntityViewModel(e.Entity);
            Items.Add(entityVM);
            SelectedItem = entityVM;
            _itemAdded = true;
            _service.Add(e.Entity);
        }

        public void OnItemEdited(object sender, SomeEntityEventArgs e)
        {
            _service.Update(e.Entity);
            Items.Clear();
            foreach (var entity in _service.GetThingsOrdered())
            {
                Items.Add(new EntityViewModel(entity));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class EntitySelectedEventArgs
    {
        public bool IsNewItem { get; set; }
        public Guid Id { get; set; }
    }

    public class SomeEntityEventArgs
    {
        public SomeEntity Entity { get; set; }
    }
}

