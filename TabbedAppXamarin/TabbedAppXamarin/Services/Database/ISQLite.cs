using SQLite;

namespace TabbedAppXamarin.Services.Database
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
