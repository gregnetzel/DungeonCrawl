using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DungeonCrawl.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewGamePage : ContentPage
	{
        Player[] players;
		public NewGamePage ()
		{
			InitializeComponent ();
            players = new Player[4];
            for (int i = 0; i < 4; i++)
                players[i] = new Player();
            PlayerListView.ItemsSource = players;
        }
       
        async void OnStartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BattlePage());
        }
    }
}
