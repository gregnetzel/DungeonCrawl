using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace DungeonCrawl.Models
{
    [Table("Monsters")]
    public class Monster:Player
    {
        [PrimaryKey]
        public Guid ID { get; private set; }
        [MaxLength(50)]
        public string DBName
        {
            get
            {
                return Name;
            }
            set
            {
                this.Name = value;
                OnPropertyChanged(nameof(DBName));
            }
        }
        private double _mult;
        [NotNull]
        public double Multiplier
        {
            get
            {
                return _mult;
            }
            set
            {
                _mult = value;
                OnPropertyChanged(nameof(Multiplier));
            }
        }
        public Monster()
        {
            maxStat = 999999;
            ID = Guid.NewGuid();
            DBName = "";
        }
        public Monster(Monster m)//to get around returning of soft copies
        {
            maxStat = 999999;
            DBName = m.DBName;
            Multiplier = m.Multiplier;
        }
        // Gives XP to battle after death
        public int DropXP()
        {
            return (Dex+Str+Spd) * 2;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
