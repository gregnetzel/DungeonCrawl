using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DungeonCrawl.Models
{
    public class Battle
    {
        public ObservableCollection<Monster> monsters;
        public ObservableCollection<Player> players;
        public List<Character> attackOrder;  //to sort monsters and players for attacking order, will sort based on speed stat
        public Battle(ObservableCollection<Player> p)
        {
            double difficulty = .75; //proportion of character stats to put into monsters
            monsters = new ObservableCollection< Monster>();
            players = new ObservableCollection<Player>();
            attackOrder = new List<Character>();
            for (int i = 0; i < 4; i++)
            {
                players.Add(p[i]);
                monsters.Add(new Monster());
            }
            StrengthenMonsters(difficulty);
            attackOrder.AddRange(players);
            attackOrder.AddRange(monsters);
            attackOrder.Sort();
            attackOrder.Reverse();
        }
        public bool isOver = false;
        public void Fight(Character attacker, Character defender)
        {
            defender.HP-=attacker.Str;
        }

        public void FightRound()
        {
            int j = 0;
            for (int i = 0; i < attackOrder.Count; i++)
            {
                if (!attackOrder[i].IsDead() && !isOver)
                {
                    j = i + 1;
                    while (attackOrder[i].GetType() == attackOrder[j % (attackOrder.Count)].GetType())                    
                        j++;
                    Fight(attackOrder[i], attackOrder[j % (attackOrder.Count)]);
                    if (attackOrder[j % (attackOrder.Count)].IsDead())
                        attackOrder.Remove(attackOrder[j % (attackOrder.Count)]);
                    if (AllMonstersDead() || AllPlayersDead())
                        isOver = true;
                }
            }
        }

        private void StrengthenMonsters(double diff)
        {
            int numStats = 0;
            int totalHP = 0;
            int lvl = 0;
            Random rng = new Random();
            foreach (var player in players)
            {
                numStats += player.Dex + player.Spd + player.Str;
                totalHP += player.HP;
                lvl += player.Level;
            }
            numStats = (int)(diff * numStats);
            int temp;
            int ind = 1;
            foreach (var monster in monsters)
            {
                temp = 0;
                monster.Name = "Monster " + ind++;
                temp = rng.Next(0,numStats-temp);
                numStats -= temp;
                GiveStatsToMonster(monster, temp);
                monster.Level = lvl / 4;
                monster.HP = totalHP / 4;
            }
        }
        private void GiveStatsToMonster(Monster mon, int stat)
        {
            Random rng = new Random();
            int stats = stat;
            int temp = rng.Next(0, stats);
            mon.Spd = temp;
            stats -= temp;
            temp = rng.Next(0, stats);
            mon.Dex = temp;
            stats -= temp;
            mon.Str = stats;
        }

        public bool AllPlayersDead()
        {
            bool playersDead = true;
            for (int i = 0; i < players.Count; i++)           
                if (players[i].HP > 0)
                    playersDead = false;
            return playersDead;
        }

        public bool AllMonstersDead()
        {
            bool monstersDead = true;
            for (int i = 0; i < monsters.Count; i++)            
                if (monsters[i].HP > 0)
                    monstersDead = false;
            return monstersDead;
        }

    }
}
