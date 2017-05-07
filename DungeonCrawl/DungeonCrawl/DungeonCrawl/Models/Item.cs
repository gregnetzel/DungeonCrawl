using SQLite;
using System.ComponentModel;
using System;

namespace DungeonCrawl.Models
{
    [Table("Items")]
    public class Item 
	{
        [PrimaryKey]
        public Guid ID { get; private set; }
        private string _name;
        [NotNull, MaxLength(50)]
        public string Name {
            get {
                return _name;
            }
            set {
                this._name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private int _str;
        [NotNull]
        public int StrValue {
            get
            {
                return _str;
            }
            set
            {
                _str = value;
                OnPropertyChanged(nameof(StrValue));
            }
        }
        private int _dex;
        [NotNull]
        public int DexValue {
            get
            {
                return _dex;
            }
            set
            {
                _dex = value;
                OnPropertyChanged(nameof(DexValue));
            }
        }
        private int _spd;
        [NotNull]
        public int SpdValue {
            get
            {
                return _spd;
            }
            set
            {
                _spd = value;
                OnPropertyChanged(nameof(SpdValue));
            }
        }
        private int _hp;
        [NotNull]
        public int HPValue {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
                OnPropertyChanged(nameof(HPValue));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
        public Item()
        {
            ID = Guid.NewGuid();
        }
    }
}
