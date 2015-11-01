using Xamarin.Forms;

namespace TabbedAppXamarin.Views
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            Children.Add(new NavigationPage(new ContactListPage()) {Title = "Contacts"});
            Children.Add(new ImageCollectionPage {Title = "Images"});
            Children.Add(new EntitiesCollectionPage{Title = "Entities"});
            Children.Add(new ImageEditorPage{ Title = "Editor"});
        }
    }
}
