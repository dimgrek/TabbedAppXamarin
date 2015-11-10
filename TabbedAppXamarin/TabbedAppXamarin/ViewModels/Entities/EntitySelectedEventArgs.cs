using System;

namespace TabbedAppXamarin.ViewModels.Entities
{
    public class EntitySelectedEventArgs
    {
        public bool IsNewItem { get; set; }
        public Guid Id { get; set; }
    }
}