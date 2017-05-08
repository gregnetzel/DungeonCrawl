using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace DungeonCrawl.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattlePage : ContentPage
	{
        public ObservableCollection<Player> players;
        public Battle battle;
        public BattlePage ()//start of auto game
		{
			InitializeComponent ();
            players = AutoPlayers();
            PlayerListView.ItemsSource = players;
            battle = new Battle(players);
            MonsterListView.ItemsSource = battle.monsters;
        }
        public BattlePage(ObservableCollection<Player> p)//normal game starter
        {
            InitializeComponent();
            players = p;
            PlayerListView.ItemsSource = players;
            battle = new Battle(players);
            MonsterListView.ItemsSource = battle.monsters;
        }
        public BattlePage(Battle bat)
        {
            InitializeComponent();
            battle = bat;
            PlayerListView.ItemsSource = battle.players;
            MonsterListView.ItemsSource = battle.monsters;
        }
        private ObservableCollection<Player> AutoPlayers()
        {
            ObservableCollection<Player> players = new ObservableCollection<Player>();
            for (int i = 0; i < 4; i++)
            {
                players.Add(new Player());
                players[i].Name = "Player " + (i + 1);
            }
            return players;
        }
        async void OnPlayerClick(object sender, SelectedItemChangedEventArgs e)
        {
            var play = e.SelectedItem as Player;
            await Navigation.PushAsync(new PlayerDetails(play));
        }
        async void OnMonsterClick(object sender, SelectedItemChangedEventArgs e)
        {
            var mons = e.SelectedItem as Monster;
            await Navigation.PushAsync(new MonsterDetails(mons));
        }
        async void OnFightClick(object sender, EventArgs e)
        {
            battle.FightRound();
            await Navigation.PushAsync(new BattlePage(battle));
        }
    }
}
