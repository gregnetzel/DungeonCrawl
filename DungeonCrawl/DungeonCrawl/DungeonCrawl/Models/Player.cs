using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DungeonCrawl.Models
{
    public class Player:Character
    {
        public int CurrentXP { get; set; }
        public ObservableCollection<Item> CurrentItems { get; set; } // What's inventory for then?
        public Player()
        {
            CurrentItems = new ObservableCollection<Item>();
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
            CurrentItems.Add(item);
        }
    }
}
