using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace DungeonCrawl.Models
{
    public class ItemDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Item> Items { get; set; }
        public ItemDataAccess()
        {
            database =
              DependencyService.Get<IDatabaseConnection>().
              DbConnection();
            database.CreateTable<Item>();
            this.Items = new ObservableCollection<Item>(database.Table<Item>());
            if (!database.Table<Item>().Any())// If empty stick in defaults
            {
                AddDefaultItems();
            }
        }
        private void AddDefaultItems()
        {
            Item temp, temp1, temp2, temp3;
            for (int i = 1; i < 11; i++)
            {

                temp = new Item
                {
                    Name = "Armor "+i,
                    HPValue = i,
                    StrValue = 0,
                    DexValue = 0,
                    SpdValue = 0,
                };
                this.Items.Add(temp);
                database.Insert(temp);

                temp1 = new Item
                {
                    Name = "Sword "+i,
                    HPValue = 0,
                    StrValue = i,
                    DexValue = 0,
                    SpdValue = 0,
                };
                this.Items.Add(temp1);
                database.Insert(temp1);

                temp2 = new Item
                {
                    Name = "Hat "+i,
                    HPValue = 0,
                    StrValue = 0,
                    DexValue = i,
                    SpdValue = 0,
                };
                this.Items.Add(temp2);
                database.Insert(temp2);

                temp3 = new Item
                {
                    Name = "Boots "+i,
                    HPValue = 0,
                    StrValue = 0,
                    DexValue = 0,
                    SpdValue = i,
                };
                this.Items.Add(temp3);
                database.Insert(temp3);
            }

        }
        public Item AddNewItem()
        {
            Item temp = new Item
            {
                Name = "",
                HPValue = 0,
                StrValue = 0,
                DexValue = 0,
                SpdValue = 0,
            };
            Items.Add(temp);
            database.Insert(temp);
            return temp;
        }
        
        public IEnumerable<Item> GetItems()
        {
            lock (collisionLock)
            {
                var query = database.Table<Item>();
                return query.AsEnumerable();
            }
        }

        public bool SaveItem(Item itemInstance)
        {
            lock (collisionLock)
            {
                if (itemInstance.ID != null)
                {
                    database.Update(itemInstance);
                    Items.Remove(itemInstance);
                    Items.Add(itemInstance);
                    return true;
                }
                return false;
            }
        }

        public bool DeleteItem(Item itemInstance)
        {
            var id = itemInstance.ID;
            if (id != null)
            {
                lock (collisionLock)
                {
                    database.Delete<Item>(id);
                }
                this.Items.Remove(itemInstance);
                return true;
            }
            this.Items.Remove(itemInstance);
            return false;
        }
        public Item GetRandomItem()
        {
            var temp = database.Query<Item>("SELECT* FROM table ORDER BY RANDOM() LIMIT 1");
            return temp[0];
        }
        public void DeleteAllItems()
        {
            lock (collisionLock)
            {
                database.DropTable<Item>();
                database.CreateTable<Item>();
            }
            this.Items = null;
            this.Items = new ObservableCollection<Item>
              (database.Table<Item>());
        }
    }
}
