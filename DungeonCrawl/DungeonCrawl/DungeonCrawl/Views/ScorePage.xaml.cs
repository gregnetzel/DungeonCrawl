using DungeonCrawl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DungeonCrawl.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScorePage : ContentPage
	{
        ObservableCollection<Player> players;
        public ScorePage (ObservableCollection<Player> play)
		{
			InitializeComponent ();
            players = play;
            PlayerListView.ItemsSource = players;
            Title = "Score";
		}
        async void OnStartNewGame(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GamePage());
        }
        async void OnPlayerClick(object sender, SelectedItemChangedEventArgs e)
        {
            var play = e.SelectedItem as Player;
            await Navigation.PushAsync(new PlayerDetails(play));
        }
    }
}
