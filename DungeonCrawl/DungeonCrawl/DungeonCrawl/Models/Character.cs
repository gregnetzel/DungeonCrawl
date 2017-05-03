using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DungeonCrawl.Models
{
    public class Character:IComparable
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public ObservableCollection<Item> CurrentItems; // item order HP, Strength, Dexterity, Speed
        private int _hp;
        public int HP { get {return _hp+CurrentItems[0].HPValue; } set {_hp = value; } }
        private int _strength;
        public int Str { get { return _strength + CurrentItems[1].StrValue; } set { _strength = value; } }
        private int _dexterity;
        public int Dex { get { return _dexterity + CurrentItems[2].DexValue; } set { _dexterity = value; } }
        private int _speed;
        public int Spd { get { return _speed + CurrentItems[3].SpdValue; } set { _speed = value; } }
        public int Level { get;set; }

        public int CompareTo(Object obj)//to make sorting the battle order easy
        {
            Character cha = obj as Character;
            return Spd.CompareTo(cha.Spd);
        }

        // Attack and Dodge should be calculated in Battle. Can just get Str, Level, Etc from Character and calculate it there
        // Attack should take 2 param, the characters that are fighting, calculate how much dmg, hit or miss in this function

        public bool IsDead()
        {
            if (HP < 1) return true;
            return false;
        }
    }
}
