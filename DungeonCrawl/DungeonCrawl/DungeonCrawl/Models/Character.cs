using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawl.Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Spd { get; set; }
        public int HP { get; set; }
        public int Level { get; set; }

        // Attack and Dodge should be calculated in Battle. Can just get Str, Level, Etc from Character and calculate it there
        // Attack should take 2 param, the characters that are fighting, calculate how much dmg, hit or miss in this function

        public bool IsDead()
        {
            if (HP < 1) return true;
            return false;
        }
    }
}
