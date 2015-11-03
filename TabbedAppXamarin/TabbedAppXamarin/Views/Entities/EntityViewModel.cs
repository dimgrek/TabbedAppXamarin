using System;
using TabbedAppXamarin.Model;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views.Entities
{
    public class EntityViewModel
    {
        private SomeEntity _entity;

        public EntityViewModel(SomeEntity entity)
        {
            _entity = entity;
        }

        public string Updated => _entity.Updated.ToString("g");

        public string Name => _entity.Name;

        public Guid Id => _entity.Id;

        public Color Color => _entity.IsActive ? Color.Transparent : Color.Silver;
    }
}
