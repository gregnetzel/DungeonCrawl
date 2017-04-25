using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawl.Models
{
    public class Monster:Player
    {
        public string Type { get; set; }

        // Creates a new Item and return it everytime it's killed
        public Item DropItem()
        {
            Item ret = new Item { }; // This is going to be randomized when we already have the Items database
            return ret;
        }

        // Gives an XP to Players that killed the monster. Assuming that XP from monsters is just its level * 2
        public int DropXP()
        {
            return Level * 2;
        }
    }
}
