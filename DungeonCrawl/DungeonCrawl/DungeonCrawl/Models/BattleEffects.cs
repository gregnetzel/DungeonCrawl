using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawl.Models
{
    class BattleEffects
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Target { get; set; } // {CHARACTERSINGLE, CHARACTERALL, MONSTERAALL, MONSTERSINGLE, ALL}
        public string AttribMod { get; set; } // {STRENGTH, SPEED, DEFENSE, HP}
        public int Tier { get; set; }
    }
}
