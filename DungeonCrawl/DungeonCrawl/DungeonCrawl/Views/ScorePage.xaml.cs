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
            Title = "Score\n";
            ScoreBox.Text = CalculateScore()+"\n";
		}
        private long CalculateScore()
        {
            long count = 0;
            foreach (Player p in players)
            {
                count += p.Level * (p.numRounds + 1);
                count += p.Spd * (p.numRounds + 1);
                count += p.Dex * (p.numRounds + 1);
                count += p.Str * (p.numRounds + 1);
            }
            return count;
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
