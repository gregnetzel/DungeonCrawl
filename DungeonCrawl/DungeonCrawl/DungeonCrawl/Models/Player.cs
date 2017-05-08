using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DungeonCrawl.Models
{
    public class Player:Character
    {
        public int CurrentXP { get; set; }
        public Player()
        {
            CurrentItems = new ObservableCollection<Item>();
            Level = 1;
            for (int i = 0; i < 4; i++)
            {
                CurrentItems.Add(new Item());
            }
            Random rng = new Random();
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

        public void AddXP(int XP)
        {
            CurrentXP += XP;
            while (CurrentXP >= 100)
            {
                LevelUp();
                CurrentXP -= 100;
            }
        }

        public void LevelUp()
        {
            Random rng = new Random();
            HP += 5*Level;
            Str += rng.Next(1, 2 * Level);
            Spd += rng.Next(1, 2 * Level);
            Dex += rng.Next(1, 2 * Level);
            Level++;
        }

        public void GetItem(Item item)
        {
            if (item.HPValue > this.CurrentItems[0].HPValue)
            {
                CurrentItems[0] = item;
            }
            else if(item.StrValue > this.CurrentItems[1].StrValue)
            {
                CurrentItems[1] = item;
            }
            else if (item.DexValue > this.CurrentItems[2].DexValue)
            {
                CurrentItems[2] = item;
            }
            else if (item.SpdValue > this.CurrentItems[3].SpdValue)
            {
                CurrentItems[3] = item;
            }
        }
    }
}
