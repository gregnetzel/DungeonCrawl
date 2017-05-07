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
	public partial class NewGamePage : ContentPage
	{
		public NewGamePage ()
		{
			InitializeComponent ();
		}
        async void OnStartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BattlePage());
        }
    }
}
