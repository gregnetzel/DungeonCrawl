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
	public partial class GamePage : ContentPage
	{
		public GamePage ()
		{
			InitializeComponent ();
		}
        async void OnScore(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScorePage());
        }

        async void OnCharacter(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharactersPage());
        }

        async void OnInventory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventoryPage());
        }

        async void OnMonsters(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MonstersPage());
        }

        async void OnItems(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPage());
        }

        async void OnBattle(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BattlePage());
        }
    }
}
