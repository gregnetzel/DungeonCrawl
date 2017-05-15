using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DungeonCrawl.Models
{
    class MonsterDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Monster> Monsters { get; set; }
        Random rng;
        public MonsterDataAccess()
        {
            database =
              DependencyService.Get<IDatabaseConnection>().
              DbConnection();
            database.CreateTable<Monster>();
            DeleteAllMonsters();
            this.Monsters = new ObservableCollection<Monster>(database.Table<Monster>());
            if (!database.Table<Monster>().Any())// If empty stick in defaults
            {
                AddDefaultMonsters();
            }
            rng = new Random();
        }
        private void AddDefaultMonsters()
        {
            Monster temp = new Monster
            {
                DBName = "Dragon",
                Multiplier = .5
            };
            this.Monsters.Add(temp);
            database.Insert(temp);
            temp = new Monster
            {
                DBName = "Orc",
                Multiplier = .5
            };
            this.Monsters.Add(temp);
            database.Insert(temp);
            temp = new Monster
            {
                DBName = "Elf",
                Multiplier = .5
            };
            this.Monsters.Add(temp);
            database.Insert(temp);
            temp = new Monster
            {
                DBName = "Cat",
                Multiplier = .5
            };
            this.Monsters.Add(temp);
            database.Insert(temp);
        }
        public Monster AddNewMonster()
        {
            Monster temp = new Monster
            {
                Name = "",
                Multiplier = .75
            };
            Monsters.Add(temp);
            database.Insert(temp);
            return temp;
        }

        public IEnumerable<Monster> GetMonsters()
        {
            lock (collisionLock)
            {
                var query = database.Table<Monster>();
                return query.AsEnumerable();
            }
        }

        public bool SaveMonster(Monster itemInstance)
        {
            lock (collisionLock)
            {
                if (itemInstance.ID != null)
                {
                    database.Update(itemInstance);
                    Monsters.Remove(itemInstance);
                    Monsters.Add(itemInstance);
                    return true;
                }
                return false;
            }
        }

        public bool DeleteMonster(Monster itemInstance)
        {
            var id = itemInstance.ID;
            if (id != null)
            {
                lock (collisionLock)
                {
                    database.Delete<Monster>(id);
                }
                this.Monsters.Remove(itemInstance);
                return true;
            }
            this.Monsters.Remove(itemInstance);
            return false;
        }
        public Monster GetRandomMonster()
        {
            return Monsters[rng.Next(0, Monsters.Count)];
        }
        public void DeleteAllMonsters()
        {
            lock (collisionLock)
            {
                database.DropTable<Monster>();
                database.CreateTable<Monster>();
            }
            this.Monsters = null;
            this.Monsters = new ObservableCollection<Monster>
              (database.Table<Monster>());
        }
    }
}
