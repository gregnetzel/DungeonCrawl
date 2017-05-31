using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DungeonCrawl;

namespace DungeonCrawl.Models
{
    public class Battle
    {
        public ObservableCollection<Monster> monsters;
        public ObservableCollection<Player> players;
        public List<Character> attackOrder;  //to sort monsters and players for attacking order, will sort based on speed stat
        private int xpPool;
        private int battleNumber;
        private List<Item> itemPool;
        private ItemDataAccess dataAccess;
        private MonsterDataAccess monsAccess;
        public double difficulty;
        Random rng;
        public Battle(ObservableCollection<Player> p, int battlNum)
        {
            battleNumber = battlNum;
            rng = new Random();
            difficulty = 0.75; //proportion of character stats to put into generated monsters
            xpPool = 0;
            dataAccess = new ItemDataAccess();
            monsAccess = new MonsterDataAccess();
            monsters = new ObservableCollection< Monster>();
            players = new ObservableCollection<Player>();
            attackOrder = new List<Character>();
            itemPool = new List<Item>();
            for (int i = 0; i < 4; i++)
            {
                players.Add(p[i]);
                monsters.Add(new Monster(monsAccess.GetRandomMonster()));
                if (!p[i].IsDead()) //keep dead guys from attackorder
                    attackOrder.Add(p[i]);
            }
            StrengthenMonsters(difficulty);
            attackOrder.AddRange(monsters);
            attackOrder.Sort();
            attackOrder.Reverse();
        }
        public bool isOver = false;
        public string Fight(Character attacker, Character defender)
        {
            string wh = "";
            int random;

            if ((bool)Xamarin.Forms.Application.Current.Properties["OnlyCrit"])
                random = 18;
            else if ((bool)Xamarin.Forms.Application.Current.Properties["OnlyMiss"])
                random = 1;
            else
                random = rng.Next(1, 20);

            //int random = rng.Next(1,20);
			int damage = attacker.Str;

            //if random is 1 it is a miss
            if (random <= 1)
            {
                if (attacker.noWeapon() && isPlayer(attacker))
                {
                    return attacker.Name + " attacked " + defender.Name + " using their fists missed\n";
                }

                return attacker.Name + " attacked " + defender.Name + " and missed\n";
            }

            //if random is >18 double attack
            else if (random >= 18)
            {
                if (isPlayer(defender))
                {
                    Player temp = (Player)defender;
                    wh += temp.DamageItems();
                }
                if (isPlayer(attacker))
                {
                    Player temp = (Player)attacker;
                    wh += temp.DamageItems();
                }
                if (attacker.noWeapon() && isPlayer(attacker))
                {
                    damage = 2;
                    defender.HP -= damage;
                    if (defender.HP < 0)
                        defender.HP = 0;
                    wh += attacker.Name + " critically attacked " + defender.Name + " using their fists so still only did " + damage + " damage.\n";
                    return wh;
                }

                damage *= 2;
                defender.HP -= damage;
				if (defender.HP < 0)
					defender.HP = 0;

                wh += attacker.Name + "  critically attacked " + defender.Name + " with the double damage of " + damage + "\n";
                return wh;
            }
            else
            {
                if (isPlayer(defender))
                {
                    Player temp = (Player)defender;
                    wh += temp.DamageItems();
                }
                if (isPlayer(attacker))
                {
                    Player temp = (Player)attacker;
                    wh += temp.DamageItems();
                }
                if (attacker.noWeapon() && isPlayer(attacker))
                {
                    damage = 2;
                    defender.HP -= damage;
                    if (defender.HP < 0)
                        defender.HP = 0;
                    wh += attacker.Name + " attacked " + defender.Name + " using their fists and did " + damage + " damage.\n";
                    return wh;
                }

                defender.HP -= damage;
                if (defender.HP < 0)
                    defender.HP = 0;

                wh += attacker.Name + " attacked " + defender.Name + " and did " + damage + " damage.\n";
                return wh;
            }
        }

        public string FightRound()
        {
            string whatHappened = "";
            int j = 0;
            for (int i = 0; i < attackOrder.Count; i++) //loop over attacking list
            {
                if (!attackOrder[i].IsDead() && !isOver)
                {
                    j = i + 1;
                    while (attackOrder[i].GetType() == attackOrder[j % (attackOrder.Count)].GetType()) //go down list until you hit first of other type               
                        j++;
                    whatHappened += Fight(attackOrder[i], attackOrder[j % (attackOrder.Count)]);
                    if (attackOrder[j % (attackOrder.Count)].IsDead()) //remove from attacking list if character died
                    {
                        whatHappened += attackOrder[j % (attackOrder.Count)].Name + " has died.\n";
                        if (attackOrder[j % (attackOrder.Count)].GetType() == typeof(Monster))//check if dead guy is monster
                        {
                            Monster temp = attackOrder[j % (attackOrder.Count)] as Monster;
                            xpPool += temp.DropXP();
                            itemPool.Add(dataAccess.GetRandomItem());
                        }
                        attackOrder.Remove(attackOrder[j % (attackOrder.Count)]);                                
                    }                        
                    if (AllMonstersDead())
                    {
                        whatHappened += "Battle Won\n";
                        foreach (Player player in players)
                        {
                            if (!player.IsDead())
                            {
                                player.numRounds++;
                                whatHappened += player.AddXP(xpPool);
                            }
                        }
                        int ind = 0;
                        while (itemPool.Count > 0)
                        {
                            if (!players[ind%4].IsDead())
                            {
                                whatHappened += players[ind % 4].GetItem(itemPool[0]);
                                itemPool.RemoveAt(0);
                            }
                            ind++;
                        }
                        isOver = true;
                    }
                    else if (AllPlayersDead())
                    {
                        whatHappened += "Battle Lost\n\n\nGame Over\n";
                        isOver = true;
                    }
                }
            }
            return whatHappened;
        }

        private void StrengthenMonsters(double diff)
        {
            int numStats = 0;
            int totalHP = 0;
            int lvl = 0;
            int playersLive = 0;
            Random rng = new Random();
            foreach (var player in players)
            {
                numStats += player.Dex + player.Spd + player.Str;
                totalHP += player.HP;
                lvl += player.Level;
                if (!player.IsDead())
                    playersLive++;
            }
            int temp;
            double multiplier;
            foreach (var monster in monsters)
            {
                temp = 0;
                temp = rng.Next(0,numStats-temp);
                numStats -= temp;
                multiplier = monster.Multiplier * (1 + battleNumber / 10.0);
                GiveStatsToMonster(monster, (int)(multiplier*temp));
                monster.Level = lvl / playersLive;
                if (totalHP * multiplier / playersLive < 1)
                    monster.HP = 1;
                else
                    monster.HP = (int)(totalHP * multiplier / playersLive);
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
  
        public bool isPlayer(Character attacker)
        {
            foreach (Character character in players)
            {
                if (attacker.Name == character.Name)
                    return true; 
            }
                return false;
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
