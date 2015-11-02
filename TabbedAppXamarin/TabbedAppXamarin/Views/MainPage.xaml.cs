using TabbedAppXamarin.Services.Entities;
using Xamarin.Forms;

namespace TabbedAppXamarin.Views
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            DependencyService.Register<EntityService>();
            Children.Add(new NavigationPage(new ContactListPage()) {Title = "Contacts"});
            Children.Add(new ImageCollectionPage {Title = "Images"});
            Children.Add(new NavigationPage(new EntityListPage()){Title = "Entities"});
            Children.Add(new ImageEditorPage{ Title = "Editor"});
        }
    }
}
