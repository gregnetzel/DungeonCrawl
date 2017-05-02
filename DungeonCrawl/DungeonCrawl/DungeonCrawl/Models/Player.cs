using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MobileApplication
{
	public class Player : Characters
	{
		public int CurrentXP { get; set; }
        public ObservableCollection<Items> CurrentItems;

        public Player()
        {
            CurrentItems = new ObservableCollection<Items>();
        }

		public void AddXP(int XP)
		{
			CurrentXP += XP;
			LevelUp();
		}

		public void LevelUp()
		{
			if (CurrentXP >= 100)
			{
				Level++;
				CurrentXP = 0;

				if (Level % 2 == 0)
				{
					Str++;
					Spd++;
				}
				else if (Level % 3 == 0)
				{
					Dex++;
					HP += 3;
				}
				else if (Level % 10 == 0)
				{
					Str++;
					Spd++;
					Dex++;
					HP += 5;
				}
				else HP += 2;
			}
		}

		public void GetItem(Items Item)
		{
            var item = CurrentItems.FirstOrDefault(i => i.InvLoc == Item.InvLoc);
            if (item == null) // Item does not exist
            {
                CurrentItems.Insert(Item.InvLoc, Item);
				this.Str += Item.StrValue;
				this.Dex += Item.DexValue;
				this.Spd += Item.SpdValue;
				this.HP += Item.HPValue;
            }
            else
            {
                // Compare the two items
				if (CurrentItems[Item.InvLoc].StrValue < Item.StrValue ||
					CurrentItems[Item.InvLoc].DexValue < Item.DexValue ||
					CurrentItems[Item.InvLoc].SpdValue < Item.SpdValue ||
					CurrentItems[Item.InvLoc].HPValue < Item.HPValue)
				{
					// If CurrentItem is worse than new Item
					this.Str += (Item.StrValue - CurrentItems[Item.InvLoc].StrValue);
					this.Dex += (Item.DexValue - CurrentItems[Item.InvLoc].DexValue);
					this.Spd += (Item.SpdValue - CurrentItems[Item.InvLoc].SpdValue);
					this.HP += (Item.HPValue - CurrentItems[Item.InvLoc].HPValue);
                    CurrentItems.RemoveAt(Item.InvLoc);
					CurrentItems.Insert(Item.InvLoc, Item); // Replace existing item
				}
            }
		}
	}
}
