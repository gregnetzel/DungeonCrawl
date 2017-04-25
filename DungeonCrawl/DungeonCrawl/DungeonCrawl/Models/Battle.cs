using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawl.Models
{
    class Battle
    {
        struct MonsterParty
        {
            public List<Monster> party;
            public void GenerateMonsters()
            {
                party.Add(new Monster());
                //todo
            }
            public bool AllDead()
            {
                //todo
                return true;
            }
        }
        struct PlayerParty
        {
            public List<Player> party;
            public bool AllDead()
            {
                //todo
                return true;
            }
        }
        public Battle(Player[] p)
        {
            MonsterParty monsters = new MonsterParty();
            PlayerParty players = new PlayerParty();
            players.party.AddRange(p);
            monsters.GenerateMonsters();
            monsters.party.Sort();
        }
    }
}
