using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawl.Models
{
    public class Battle
    {
        public List<Monster> monsters;
        public List<Player> players;
        public List<Character> attackOrder;  //to sort monsters and players for attacking order, will sort based on speed stat
        public Battle(Player[] p)
        {
            monsters = new List<Monster>();
            players = new List<Player>();
            attackOrder = new List<Character>();
            players.AddRange(p);
            for (int i = 0; i < 4; i++)
            {
                monsters.Add(new Monster());
            }
            attackOrder.AddRange(players);
            attackOrder.AddRange(monsters);
            attackOrder.Sort();
            attackOrder.Reverse();
        }
        public void Fight(Character attacker, Character defender)
        {

        }
        public bool IsOver()
        {
            bool playersDead = true;
            bool monstersDead = true;
            for (int i = 0; i < 4; i++)
            {
                if (players[i].HP > 0)                
                    playersDead = false;
                if (monsters[i].HP > 0)
                    monstersDead = false;
            }
            if (playersDead || monstersDead)
            {
                return true;
            }
            return false;
        }
    }
}
