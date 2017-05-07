using System;
using SQLite;
using System.IO;
using DungeonCrawl.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace DungeonCrawl.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "DungeonDB.db3";
            var path = Path.Combine(System.Environment.
              GetFolderPath(System.Environment.
              SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}