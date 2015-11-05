using SQLite;

namespace TabbedAppXamarin.Services.Database
{
    public interface ISQIite
    {
        SQLiteConnection GetConnection();
    }
}
