using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DungeonCrawl.Models;

namespace DungeonCrawl.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonsterDetails : ContentPage
	{
		public MonsterDetails ()
		{
			InitializeComponent ();
		}
        public MonsterDetails(Monster mon)
        { 
            InitializeComponent();

            Title = mon.Name;
            MonsDetails.Text = $"Health: {mon.HP}\n Strength: {mon.Str}\n Dexterity: {mon.Dex}\n Speed: {mon.Spd}";
        }
    }
}
