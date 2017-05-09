using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DungeonCrawl.Models
{
    public class Monster:Player
    {
        public string Type { get; set; }

        public Monster()
        {
            CurrentItems = new ObservableCollection<Item>();
            for (int i = 0; i < 4; i++)
            {
                CurrentItems.Add(new Item());
            }
        }
        // Creates a new Item and return it everytime it's killed
        public Item DropItem()
        {
            Item ret = new Item { }; // This is going to be randomized when we already have the Items database
            return ret;
        }

        // Gives XP to battle after death
        public int DropXP()
        {
            return (Dex+Str+Spd) * 2;
        }
    }
}
