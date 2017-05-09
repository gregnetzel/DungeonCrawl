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
            ItemListView.ItemsSource = player.CurrentItems;

            CharDetails.Text = $" Level: {player.Level}\n HP: {player.HP}\n Str: {player.Str}\n Dex: {player.Dex}\n Spd: {player.Spd}";
        }
        async void OnItemClick(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Item;
            await Navigation.PushAsync(new ItemsDetails(item));
        }
    }
}
