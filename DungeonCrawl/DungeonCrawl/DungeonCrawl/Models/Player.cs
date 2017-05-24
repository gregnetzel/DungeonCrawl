using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DungeonCrawl.Models
{
    public class Player:Character
    {
        static Random rng = new Random();
        public int CurrentXP { get; set; }
        private int _rounds;
        public int numRounds { get { return _rounds; } set { _rounds = value; } }
        public string NameRound { get { return Name+": Rounds Survived: "+numRounds; } }

        public Player()
        {
            maxStat = 99999;
            CurrentItems = new ObservableCollection<Item>();
            Level = 1;
            for (int i = 0; i < 4; i++)
            {
                CurrentItems.Add(new Item());
            }
            int stats = 10;
            HP = stats;
            int temp = rng.Next(0, stats);
            Spd = temp;
            stats -= temp;
            temp = rng.Next(0, stats);
            Dex = temp;
            stats -= temp;
            Str = stats;
        }

        public string AddXP(int XP)
        {
            string temp="";
            CurrentXP += XP;
            while (CurrentXP >= 50*Level)
            {
                temp += LevelUp();
                CurrentXP -= 50*Level;
            }
            return temp;
        }

        public string LevelUp()
        {
            Random rng = new Random();
            HP += 2*Level;
            Str += rng.Next(1, 2 * Level);
            Spd += rng.Next(1, 2 * Level);
            Dex += rng.Next(1, 2 * Level);
            Level++;
            return Name + " has risen to level " + Level + ".\n";
        }

        public string GetItem(Item item)
        {
            string temp = "Player " + Name + " found and item: " + item.Name;
            if (item.HPValue > this.CurrentItems[0].HPValue)
            {
                CurrentItems[0] = item;
                temp += " and equipped it.\n";
            }
            else if(item.StrValue > this.CurrentItems[1].StrValue)
            {
                CurrentItems[1] = item;
                temp += " and equipped it.\n";
            }
            else if (item.DefValue > this.CurrentItems[2].DefValue)
            {
                CurrentItems[2] = item;
                temp += " and equipped it.\n";
            }
            else if (item.SpdValue > this.CurrentItems[3].SpdValue)
            {
                CurrentItems[3] = item;
                temp += " and equipped it.\n";
            }
            else
                temp += " and did not equip it.\n";
            return temp;
        }
    }
}
