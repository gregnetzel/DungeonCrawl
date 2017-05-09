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
	public partial class ScorePage : ContentPage
	{
		public ScorePage ()
		{
			InitializeComponent ();
            Title = "Score";
		}
        async void OnStartNewGame(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewGamePage());
        }
        
    }
}
