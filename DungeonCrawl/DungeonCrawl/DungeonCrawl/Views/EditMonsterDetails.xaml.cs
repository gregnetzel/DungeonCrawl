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
	public partial class EditMonsterDetails : ContentPage
	{
        private MonsterDataAccess dataAccess;
        private Monster tMonster;
        public EditMonsterDetails()
        {
            InitializeComponent();
            dataAccess = new MonsterDataAccess();
        }
        public EditMonsterDetails(Monster m)
        {
            InitializeComponent();
            dataAccess = new MonsterDataAccess();
            tMonster = m;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = tMonster;
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            dataAccess.SaveMonster(tMonster);
            await Navigation.PushAsync(new MonstersPage());
        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            dataAccess.DeleteMonster(tMonster);
            await Navigation.PushAsync(new MonstersPage());
        }
    }
}
