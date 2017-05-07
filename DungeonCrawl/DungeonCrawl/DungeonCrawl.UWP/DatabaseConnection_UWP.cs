using SQLite;
using Xamarin.Forms;
using DungeonCrawl.UWP;
using Windows.Storage;
using System.IO;

[assembly: Dependency(typeof(DatabaseConnection_UWP))]
namespace DungeonCrawl.UWP
{
    public class DatabaseConnection_UWP : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "DungeonDB.db3";
            var path = Path.Combine(ApplicationData.
              Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(path);
        }
    }
}
