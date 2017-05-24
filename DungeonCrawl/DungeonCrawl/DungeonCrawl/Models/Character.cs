﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DungeonCrawl.Models
{
    public class Character:IComparable
    {
        public int maxStat;
        public string Name { get; set; }
        public string Icon { get; set; }
        public ObservableCollection<Item> CurrentItems; // item order HP, Strength, Dexterity, Speed
        private int _hp;
        public int HP  {
            get { return _hp + CurrentItems[0].HPValue; }
            set {
                if (value >= maxStat)
                    _hp = maxStat;
                else
                    _hp = value - CurrentItems[0].HPValue; } }
        private int _strength;
        public int Str {
            get { return _strength + CurrentItems[1].StrValue; }
            set {
                if (value >= maxStat)
                    _strength = maxStat;
                else
                    _strength = value; } }
        private int _dexterity;
        public int Dex {
            get { return _dexterity + CurrentItems[2].DefValue; }
            set {
                if (value >= maxStat)
                    _dexterity = maxStat;
                else
                    _dexterity = value; } }
        public int Defense { get { return Dex; } } //cover for dex since apparently we are using def instead
        private int _speed;
        public int Spd {
            get { return _speed + CurrentItems[3].SpdValue; }
            set {if (value >= maxStat)
                    _speed = maxStat;
                else
                    _speed = value; } }
        public int Level { get;set; }
        public string NameAndHealth { get { return Name + " has " + HP + " health remaining."; } }
        public int CompareTo(Object obj)//to make sorting the battle order easy
        {
            Character cha = obj as Character;
            return Spd.CompareTo(cha.Spd);
        }
        

        public bool IsDead()
        {
            if (HP < 1) return true;
            return false;
        }
        public override string ToString()
        {
            return NameAndHealth;
        }

        public bool noWeapon()
        {          
            foreach (Item item in CurrentItems)
            {
                if (item.StrValue > 0)
                    return false; 
            }

            if (CurrentItems.Count == 0)
            {
                Item fists = new Item();
                fists.Name = "Fists";
                fists.StrValue = 2;

                CurrentItems.Add(fists); 
            }

            return true; 
        }
    }
}
