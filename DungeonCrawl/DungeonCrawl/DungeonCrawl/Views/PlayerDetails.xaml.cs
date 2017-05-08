using DungeonCrawl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DungeonCrawl.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerDetails : ContentPage
	{
		public PlayerDetails ()
		{
			InitializeComponent ();
		}
        public PlayerDetails(Player player)
        {
            InitializeComponent();

            Title = player.Name;

            CharDetails.Text = $" Level: {player.Level}\n HP: {player.HP}\n Str: {player.Str}\n Dex: {player.Dex}\n Spd: {player.Spd}";
        }
    }
}
