using System;
using System.IO;
using SQLite;
using TabbedAppXamarin.iOS.Services.Database;
using TabbedAppXamarin.Services.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteTouch))]
namespace TabbedAppXamarin.iOS.Services.Database
{
    public class SQLiteTouch : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var libraryPath = documentsPath;//Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}
