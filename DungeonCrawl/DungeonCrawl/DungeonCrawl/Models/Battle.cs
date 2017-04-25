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
                foreach(Monster m in party)
                {
                    if (!m.IsDead())
                        return false;
                }
                return true;
            }
        }
        struct PlayerParty
        {
            public List<Player> party;
            public bool AllDead()
            {
                foreach (Player p in party)
                {
                    if (!p.IsDead())
                        return false;
                }
                return true;
            }
        }
        MonsterParty monsters;
        PlayerParty players;
        List<Character> attackOrder;  //to sort monsters and players for attacking order, will sort based on speed stat
        public Battle(Player[] p)
        {
            monsters = new MonsterParty();
            players = new PlayerParty();
            players.party.AddRange(p);
            monsters.GenerateMonsters();
            attackOrder.AddRange(players.party);
            attackOrder.AddRange(monsters.party);
            attackOrder.Sort();
        }
        public void Fight(Character attacker, Character defender)
        {

        }
        public bool IsOver()
        {
            if (players.AllDead() || monsters.AllDead())
            {
                return true;
            }
            return false;
        }
    }
}
