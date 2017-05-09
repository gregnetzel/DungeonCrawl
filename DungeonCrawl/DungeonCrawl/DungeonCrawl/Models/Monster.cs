using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DungeonCrawl.Models
{
    public class Monster:Player
    {
        public string Type { get; set; }

        public Monster() { }

        // Gives XP to battle after death
        public int DropXP()
        {
            return (Dex+Str+Spd) * 2;
        }
    }
}
