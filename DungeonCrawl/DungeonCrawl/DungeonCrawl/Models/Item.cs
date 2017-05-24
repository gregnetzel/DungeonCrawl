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
        [MaxLength(50)]
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

        private int _def;
        public int DefValue {
            get
            {
                return _def;
            }
            set
            {
                _def = value;
                OnPropertyChanged(nameof(DefValue));
            }
        }

        private int _spd;
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

        private string _image;
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        
        private string _creator;
        public string Creator
        {
            get
            {
                return _creator;
            }
            set
            {
                _creator = value;
                OnPropertyChanged(nameof(Creator));
            }
        }

        private int _usage;
        public int Usage
        {
            get
            {
                return _usage;       
            }
            set
            {
                _usage = value;
                OnPropertyChanged(nameof(Usage));
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
            Name = "";
            Image = "defaultItem.jpg";
            Usage = 100;
            HPValue = 0;
            SpdValue = 0;
            StrValue = 0;
            DefValue = 0;
        }
    }
}
