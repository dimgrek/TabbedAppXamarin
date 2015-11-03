using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TabbedAppXamarin.Model;
using TabbedAppXamarin.Services.Entities;
using Xamarin.Forms;

namespace TabbedAppXamarin.ViewModels
{
    public class EntityListViewModel
    {
        private IEntityService _service;

        public EntityListViewModel(IEntityService service)
        {
            _service = service;
            Entities = new ObservableCollection<SomeEntity>(service.GetThingsOrdered());
            AddCommand = new Command(Add);
            DeleteCommand = new Command<SelectedItemChangedEventArgs>(Delete);
            OnSelectionCommand = new Command<SelectedItemChangedEventArgs>(OnSelection);
        }

        public ObservableCollection<SomeEntity> Entities { get; set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand OnSelectionCommand { get; private set; }
        public event EventHandler AddItemClicked;
        public event EventHandler<EntitySelectedEventArgs> ItemSelected;
        public event EventHandler<EntitySelectedEventArgs> ItemDeleted;

        private void Add()
        {
            AddItemClicked?.Invoke(this, EventArgs.Empty);
        }

        public void Delete(object sender, SomeEntityEventArgs entity)
        {
            Entities.Remove(Entities.Single(o => o.Id == entity.Entity.Id));
        }

        private void Delete(SelectedItemChangedEventArgs e)
        {
            var entity = e.SelectedItem as SomeEntity;
            if (entity == null)
                return;

            Entities.Remove(Entities.Single(o => o.Id == entity.Id));
            _service.Delete(entity);
            ItemDeleted?.Invoke(this, new EntitySelectedEventArgs { Id = entity.Id });
        }

        private void OnSelection(SelectedItemChangedEventArgs e)
        {
            var entity = e.SelectedItem as SomeEntity;
            if (entity == null)
                return;
            ItemSelected?.Invoke(this, new EntitySelectedEventArgs { Id = entity.Id });
        }

        public void OnNewItemAdded(object sender, SomeEntityEventArgs e)
        {
            Entities.Add(e.Entity);
            _service.Add(e.Entity);
        }

        public void OnItemEdited(object sender, SomeEntityEventArgs e)
        {
            _service.Update(e.Entity);
            Entities.Clear();
            foreach (var entity in _service.GetThingsOrdered())
            {
                Entities.Add(entity);
            }
        }
    }

    public class EntitySelectedEventArgs
    {
        public Guid Id { get; set; }
    }

    public class SomeEntityEventArgs
    {
        public SomeEntity Entity { get; set; }
    }
}

