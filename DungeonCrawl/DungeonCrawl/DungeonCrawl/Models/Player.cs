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
            for (int i = 0; i < 4; i++)
            {
                CurrentItems.Add(new Item());
            }
        }

        public void AddXP(int XP)
        {
            CurrentXP += XP;
            if (CurrentXP >= 100)
                LevelUp();
                
        }

        public void LevelUp()
        {
            CurrentXP = 0;
            Level++;

            if (Level % 2 == 0)
            {
                Str++;
                Spd++;
            }
            else if (Level % 3 == 0)
            {
                Dex++;
                HP += 3;
            }
            else if (Level % 10 == 0)
            {
                Str++;
                Spd++;
                Dex++;
                HP += 5;
            }
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
