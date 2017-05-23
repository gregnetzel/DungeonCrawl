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

        /*
        private string _image;
        [NotNull]
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

        private string _description;
        [NotNull]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _bodyPart;
        [NotNull]
        public string BodyPart
        {
            get
            {
                return _bodyPart;
            }
            set
            {
                _bodyPart = value;
                OnPropertyChanged(nameof(BodyPart));
            }
        }

        private int _tier; // I feel like we do not need this bcs we can just use IF statements to check ATTRIBMOD and put the attribute modif in their specific values
        [NotNull]
        public int Tier
        {
            get
            {
                return _tier;
            }
            set
            {
                _tier = value;
                OnPropertyChanged(nameof(Tier));
            }
        }

        private string _attribMod;
        [NotNull]
        public string AttribMod
        {
            get
            {
                return _attribMod;
            }
            set
            {
                _attribMod = value;
                OnPropertyChanged(nameof(AttribMod));
            }
        }

        private int _usage;
        [NotNull]
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
        */
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
