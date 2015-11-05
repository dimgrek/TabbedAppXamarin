using System;
using System.IO;
using SQLite;
using TabbedAppXamarin.iOS.Services.Database;
using TabbedAppXamarin.Services.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteTouch))]
namespace TabbedAppXamarin.iOS.Services.Database
{
    public class SQLiteTouch : ISQIite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TodoSQLite5.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = documentsPath;
            var path = Path.Combine(libraryPath, sqliteFilename);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}
