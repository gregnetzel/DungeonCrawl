using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;

namespace DungeonCrawl.Models
{
    public class ItemDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Item> Items { get; set; }
        Random rng;
        public ItemDataAccess()
        {
            database =
              DependencyService.Get<IDatabaseConnection>().
              DbConnection();
            database.CreateTable<Item>();
            this.Items = new ObservableCollection<Item>(database.Table<Item>());
            if (!database.Table<Item>().Any())// If empty stick in defaults
            {
                DeleteAllItems();
                AddDefaultItems();
            }
            rng = new Random();
            
        }
        public class JObj // temp obj to hold return from post
        {
            [JsonProperty(PropertyName = "error_code")]
            public string error_code;
            [JsonProperty(PropertyName = "msg")]
            string msg;
            [JsonProperty(PropertyName = "data")]
            public APItem[] data;
        }

        public struct PostData //temp struct to format post
        {            
            [JsonProperty(PropertyName = "randomItemOption")]
            public int random;
            [JsonProperty(PropertyName = "superItemOption")]
            public int super;
        }

        public async void GetAPIItems(bool rand, bool super)
        {
            database.DeleteAll<Item>();
            int randI = 0;
            int superI = 0;
            if (rand == true)
                randI = 1;
            if (super == true)
                superI = 1;
            var temp = await GetItemsAsync(randI, superI);
            foreach (var item in temp.data)
            {
                SaveItem(item);
            }
        }

        public async Task<JObj> GetItemsAsync(int rand, int sup)
        {
            string post = JsonConvert.SerializeObject(new PostData { random = rand, super = sup });
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = $"http://gamehackathon.azurewebsites.net/api/GetItemsList";
            var response = await client.PostAsync(address, new StringContent(post, Encoding.UTF8, "application/json"));
            var itemJson = response.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<JObj>(itemJson);
            return obj;
        }

        public void AddDefaultItems()
        {
            Item temp, temp1, temp2, temp3;
            for (int i = 1; i < 11; i++)
            {

                temp = new Item
                {
                    Name = "Armor " + i,
                    HPValue = 0,
                    StrValue = 0,
                    DefValue = i,
                    SpdValue = 0,
                    Usage = i * 5,
                };
                this.Items.Add(temp);
                database.Insert(temp);

                temp1 = new Item
                {
                    Name = "Sword " + i,
                    HPValue = 0,
                    StrValue = i,
                    DefValue = 0,
                    SpdValue = 0,
                    Usage = i * 5,
                };
                this.Items.Add(temp1);
                database.Insert(temp1);

                temp2 = new Item
                {
                    Name = "Food " + i,
                    HPValue = i,
                    StrValue = 0,
                    DefValue = 0,
                    SpdValue = 0,
                    Usage = i * 5,
                };
                this.Items.Add(temp2);
                database.Insert(temp2);

                temp3 = new Item
                {
                    Name = "Boots " + i,
                    HPValue = 0,
                    StrValue = 0,
                    DefValue = 0,
                    SpdValue = i,
                    Usage = i * 5,
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
                DefValue = 0,
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
        public void SaveItem(APItem itemInstance)
        {
            int spd = 0;
            int hp = 0;
            int str = 0;
            int def = 0;
            if (itemInstance.AttribMod == "SPEED")
                spd = itemInstance.Tier;
            if (itemInstance.AttribMod == "STRENGTH")
                str = itemInstance.Tier;
            if (itemInstance.AttribMod == "HP")
                hp = itemInstance.Tier;
            if (itemInstance.AttribMod == "DEFENSE")
                def = itemInstance.Tier;
            Item item = new Item
            {
                Name = itemInstance.Name,
                StrValue = str,
                SpdValue = spd,
                DefValue = def,
                HPValue = hp,
                Creator = itemInstance.Creator,
                Usage = itemInstance.Usage,
                Image = itemInstance.Image
            };
            Items.Add(item);
            database.Insert(item);                    
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
            return Items[rng.Next(0,Items.Count)];
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
