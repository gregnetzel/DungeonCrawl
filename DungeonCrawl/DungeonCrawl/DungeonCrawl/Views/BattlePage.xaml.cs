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
        private bool OnAuto = false;
        public BattlePage ()//start of auto game
		{
			InitializeComponent ();
            players = AutoPlayers();
            PlayerListView.ItemsSource = players;
            battle = new Battle(players);
            MonsterListView.ItemsSource = battle.monsters;
            OnAuto = true;
        }
        public BattlePage(ObservableCollection<Player> p, bool auto)//normal game starter
        {
            InitializeComponent();
            OnAuto = auto;
            players = p;
            PlayerListView.ItemsSource = players;
            battle = new Battle(players);
            MonsterListView.ItemsSource = battle.monsters;
        }
        public BattlePage(Battle bat, bool auto)//continuing battle pages
        {
            players = bat.players;
            InitializeComponent();
            battle = bat;
            OnAuto = auto;
            if (auto == true)//auto logic
            {
                GameOut.Text = AutoBattle();
                if (battle.AllPlayersDead())
                {
                    FightRound.Text = "Score Screen";
                    FightRound.Clicked += OnScoreClick;
                }
                else
                {
                    throw new Exception("The game should have been over.");
                }
            }
            else
            {
                GameOut.Text = battle.FightRound();
                if (battle.isOver)
                {
                    if (battle.AllMonstersDead())
                    {
                        FightRound.Text = "Next Battle";
                        FightRound.Clicked += OnNextBattleClick;
                    }
                    if (battle.AllPlayersDead())
                    {
                        FightRound.Text = "Score Screen";
                        FightRound.Clicked += OnScoreClick;
                    }
                }                
            }
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
            await Navigation.PushAsync(new BattlePage(battle, OnAuto));
        }
        async void OnNextBattleClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BattlePage(battle.players, OnAuto));
        }
        async void OnScoreClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScorePage());
        }
        private string AutoBattle()
        {
            string temp = "";
            int maxStringLength = 10000000;
            while (!battle.AllPlayersDead())
            {
                temp = Trunc(temp, maxStringLength);
                if (battle.AllMonstersDead())
                {
                    battle = new Battle(players);
                }
                temp += battle.FightRound();
            }
            return temp;
        }
        public string Trunc(string str, int max)
        {
            if (str.Length > max)
            {
                return str.Substring(0, max);
            }
            return str;
        }
    }
}
