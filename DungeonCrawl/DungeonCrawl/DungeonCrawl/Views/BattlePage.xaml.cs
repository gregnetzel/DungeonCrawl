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
        private int battleCt;
        Random rng;
        public BattlePage ()//start of auto game
		{
			InitializeComponent ();
            players = AutoPlayers();
            PlayerListView.ItemsSource = players;
            battle = new Battle(players, 1);
            MonsterListView.ItemsSource = battle.monsters;
            OnAuto = true;
        }
        public BattlePage(ObservableCollection<Player> p, bool auto, int bCount)//normal game starter
        {
            battleCt = bCount;
            InitializeComponent();
            OnAuto = auto;
            players = p;
            PlayerListView.ItemsSource = players;
            battle = new Battle(players, ++battleCt);
            MonsterListView.ItemsSource = battle.monsters;
        }
        public BattlePage(Battle bat, bool auto)//continuing battle pages
        {
            players = bat.players;
            InitializeComponent();
            battle = bat;
            OnAuto = auto;
            rng = new Random();

            // --------------------------------------------------- BATTLE EFFECT STARTS HERE ------------------------------------------------------------------------------
            if ((bool)Application.Current.Properties["BattleEventsAllowed"])
            {
                int totalBattleEffect = App.BattleEffectManager.BattleEffectsList.Count;

                int PickABattleEffect = rng.Next(0, totalBattleEffect);

                BattleEffects BattleEffectChosen = App.BattleEffectManager.BattleEffectsList[PickABattleEffect];

                BattleEffectNameLabel.Text = BattleEffectChosen.Name;

                if (BattleEffectChosen.Target == "CHARACTERALL")
                {
                    foreach (Player p in players)
                    {
                        if (BattleEffectChosen.AttribMod == "STRENGTH")
                            p.Str += BattleEffectChosen.Tier;
                        else if (BattleEffectChosen.AttribMod == "SPEED")
                            p.Spd += BattleEffectChosen.Tier;
                        else if (BattleEffectChosen.AttribMod == "DEFENSE")
                            p.Dex += BattleEffectChosen.Tier;
                        else
                        {
                            p.HP += BattleEffectChosen.Tier;
                            if (p.HP < 0) p.HP = 0;
                            if (battle.AllPlayersDead())
                            {
                                FightRound.Text = "Score Screen";
                                FightRound.Clicked -= OnFightClick;
                                FightRound.Clicked += OnScoreClick;
                            }
                        }
                        BattleEffectLabel.Text = "All players have their " + BattleEffectChosen.AttribMod + "affected by " + BattleEffectChosen.Tier; 
                    }
                }
                else if (BattleEffectChosen.Target == "CHARACTERSINGLE")
                {
                    int PickRandomChar = rng.Next(0, 4);
                    Player p = players[PickRandomChar];
                    if (BattleEffectChosen.AttribMod == "STRENGTH")
                        p.Str += BattleEffectChosen.Tier;
                    else if (BattleEffectChosen.AttribMod == "SPEED")
                        p.Spd += BattleEffectChosen.Tier;
                    else if (BattleEffectChosen.AttribMod == "DEFENSE")
                        p.Dex += BattleEffectChosen.Tier;
                    else
                    {
                        p.HP += BattleEffectChosen.Tier;
                        if (p.HP < 0) p.HP = 0;
                        if (battle.AllPlayersDead())
                        {
                            FightRound.Text = "Score Screen";
                            FightRound.Clicked -= OnFightClick;
                            FightRound.Clicked += OnScoreClick;
                        }
                    }
                    BattleEffectLabel.Text = p.Name + " have it's " + BattleEffectChosen.AttribMod + " affected by " + BattleEffectChosen.Tier;
                }
                else if (BattleEffectChosen.Target == "MONSTERAALL")
                {
                    foreach (Monster m in battle.monsters)
                    {
                        if (BattleEffectChosen.AttribMod == "STRENGTH")
                            m.Str += BattleEffectChosen.Tier;
                        else if (BattleEffectChosen.AttribMod == "SPEED")
                            m.Spd += BattleEffectChosen.Tier;
                        else if (BattleEffectChosen.AttribMod == "DEFENSE")
                            m.Dex += BattleEffectChosen.Tier;
                        else
                        {
                            m.HP += BattleEffectChosen.Tier;
                            if (m.HP < 0) m.HP = 0;
                        }
                        BattleEffectLabel.Text = "All monsters have their " + BattleEffectChosen.AttribMod + " affected by " + BattleEffectChosen.Tier;
                    }
                }
                else if (BattleEffectChosen.Target == "MONSTERSINGLE")
                {
                    int PickRandomMonster = rng.Next(0, 4);
                    Monster m = battle.monsters[PickRandomMonster];
                    if (BattleEffectChosen.AttribMod == "STRENGTH")
                        m.Str += BattleEffectChosen.Tier;
                    else if (BattleEffectChosen.AttribMod == "SPEED")
                        m.Spd += BattleEffectChosen.Tier;
                    else if (BattleEffectChosen.AttribMod == "DEFENSE")
                        m.Dex += BattleEffectChosen.Tier;
                    else
                    {
                        m.HP += BattleEffectChosen.Tier;
                        if (m.HP < 0) m.HP = 0;
                    }
                    BattleEffectLabel.Text = m.Name + " have it's " + BattleEffectChosen.AttribMod + " affected by " + BattleEffectChosen.Tier;
                }
                else if (BattleEffectChosen.Target == "ALL")
                {
                    foreach (Player p in players)
                    {
                        if (BattleEffectChosen.AttribMod == "STRENGTH")
                            p.Str += BattleEffectChosen.Tier;
                        else if (BattleEffectChosen.AttribMod == "SPEED")
                            p.Spd += BattleEffectChosen.Tier;
                        else if (BattleEffectChosen.AttribMod == "DEFENSE")
                            p.Dex += BattleEffectChosen.Tier;
                        else
                        {
                            p.HP += BattleEffectChosen.Tier;
                            if (p.HP < 0) p.HP = 0;
                            if (battle.AllPlayersDead())
                            {
                                FightRound.Text = "Score Screen";
                                FightRound.Clicked -= OnFightClick;
                                FightRound.Clicked += OnScoreClick;
                            }
                        }
                    }
                    foreach (Monster m in battle.monsters)
                    {
                        if (BattleEffectChosen.AttribMod == "STRENGTH")
                            m.Str += BattleEffectChosen.Tier;
                        else if (BattleEffectChosen.AttribMod == "SPEED")
                            m.Spd += BattleEffectChosen.Tier;
                        else if (BattleEffectChosen.AttribMod == "DEFENSE")
                            m.Dex += BattleEffectChosen.Tier;
                        else
                        {
                            m.HP += BattleEffectChosen.Tier;
                            if (m.HP < 0) m.HP = 0;
                        }
                    }
                    BattleEffectLabel.Text = "Everyone have their " + BattleEffectChosen.AttribMod + " affected by " + BattleEffectChosen.Tier;
                }
            }

            // --------------------------------------------------- BATTLE EFFECT ENDS HERE ------------------------------------------------------------------------------

            if (auto == true)//auto logic
            {
                GameOut.Text = AutoBattle();
                if (battle.AllPlayersDead())
                {
                    FightRound.Text = "Score Screen";
                    FightRound.Clicked -= OnFightClick;
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
                        FightRound.Clicked -= OnFightClick;
                        FightRound.Clicked += OnNextBattleClick;
                    }
                    if (battle.AllPlayersDead())
                    {
                        FightRound.Text = "Score Screen";
                        FightRound.Clicked -= OnFightClick;
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
            await Navigation.PushAsync(new BattlePage(battle.players, OnAuto, battleCt));
        }
        async void OnScoreClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScorePage(players));
        }
        private string AutoBattle()
        {
            string temp = "Game Over";
            int ind = 1;
            while (!battle.AllPlayersDead())
            {
                if (battle.AllMonstersDead())
                {
                    battle = new Battle(players,ind++);
                }
                battle.FightRound();
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
