using System.Windows.Input;
using Xamarin.Forms;

namespace TabbedAppXamarin.Behaviors
{
    public class SearchBarTextChanged : Xamarin.Behaviors.Behavior
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create<SearchBarTextChanged, ICommand>(p => p.Command, null);

        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttach()
        {
            var search = AssociatedObject as SearchBar;

            if (null != search)
            {
                search.TextChanged += OnTextChanged;
            }
        }

        protected override void OnDetach()
        {
            var search = AssociatedObject as SearchBar;

            if (null != search)
            {
                search.TextChanged -= OnTextChanged;
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (null != Command)
            {
                Command.Execute(e.NewTextValue);
            }
        }
    }
}
    
