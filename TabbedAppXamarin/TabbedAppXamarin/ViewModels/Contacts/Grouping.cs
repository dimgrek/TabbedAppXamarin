using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TabbedAppXamarin.ViewModels
{
    public class Grouping<TKey, TValue> : ObservableCollection<TValue>
    {
        public Grouping(TKey key, IEnumerable<TValue> items)
        {
            Key = key;

            foreach (var item in items)
                Items.Add(item);
        }

        public TKey Key { get; private set; }
    }
}
