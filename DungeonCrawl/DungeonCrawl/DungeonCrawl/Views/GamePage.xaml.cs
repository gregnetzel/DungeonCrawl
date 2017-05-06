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

        async void OnNewGame(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewGamePage());
        }

        async void OnAutoPlay(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BattlePage());
        }
    }
}
