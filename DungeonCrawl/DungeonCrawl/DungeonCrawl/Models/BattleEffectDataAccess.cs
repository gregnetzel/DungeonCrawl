using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawl.Models
{
    public class BattleEffectDataAccess
    {
        public List<BattleEffects> BattleEffectsList;

        public BattleEffectDataAccess()
        {
            BattleEffectsList = new List<BattleEffects>();

            AddDefaultBattleEffects();
        }

        void AddDefaultBattleEffects()
        {
            BattleEffectsList.Add(new BattleEffects
            {
                Name = "Nothing",
                Description = "Nothing happened",
                Tier = 0,
                Target = "ALL",
                AttribMod = "SPEED"
            });
            BattleEffectsList.Add(new BattleEffects
            {
                Name = "Flames",
                Description = "Room bursts into flames, everyone take damage",
                Tier = -5,
                Target = "ALL",
                AttribMod = "HP"
            });
            BattleEffectsList.Add(new BattleEffects
            {
                Name = "Your are getting sleepy",
                Description = "Character loose speed",
                Tier = -5,
                Target = "CHARACTERSINGLE",
                AttribMod = "SPEED"
            });
        }
    }
}
