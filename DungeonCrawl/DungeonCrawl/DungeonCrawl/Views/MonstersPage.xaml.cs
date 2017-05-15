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
	public partial class MonstersPage : ContentPage
	{
        public ObservableCollection<Monster> MonstersList = new ObservableCollection<Monster>();
        private MonsterDataAccess dataAccess;
        public MonstersPage()
        {
            InitializeComponent();
            this.dataAccess = new MonsterDataAccess();

            Title = "Monsters";

            MonstersView.ItemsSource = MonstersList;
            PopulateMonsters();
        }

        void PopulateMonsters()
        {
            var templist = dataAccess.GetMonsters();
            MonstersList.Clear();
            foreach (Monster i in templist)
            {
                MonstersList.Add(i);
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulateMonsters();
        }
        async void OnMonsterClick(object sender, SelectedItemChangedEventArgs e)
        {
            var monster = e.SelectedItem as Monster;
            await Navigation.PushAsync(new EditMonsterDetails(monster));
        }
        async void OnAddClicked(object sender, SelectedItemChangedEventArgs e)
        {
            Monster monster = dataAccess.AddNewMonster();
            await Navigation.PushAsync(new EditMonsterDetails(monster));
        }
        async void OnDeleteAllClicked(object sender, SelectedItemChangedEventArgs e)
        {
            dataAccess.DeleteAllMonsters();
            BindingContext = dataAccess;
            await Navigation.PushAsync(new MonstersPage());
        }
    }
}
