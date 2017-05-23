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
	public partial class Settings : ContentPage
	{
		public Settings ()
		{
			InitializeComponent ();
		}
        private void OnUseServerItems(object sender, EventArgs e)
        {
            if (ItemsFromServerSwitch.IsToggled)
            {
                RandomResultsSwitch.IsEnabled = true;
                SuperResultsSwitch.IsEnabled = true;
            }
            else
            {
                RandomResultsSwitch.IsEnabled = false;
                SuperResultsSwitch.IsEnabled = false;
            }
        }

        private void OnRandomResults(object sender, EventArgs e)
        {

        }

        private void OnSuperResults(object sender, EventArgs e)
        {

        }

        private void OnCriticalSwitch(object sender, EventArgs e)
        {

        }

        private void OnItemUsage(object sender, EventArgs e)
        {

        }

        private void OnMagicUsage(object sender, EventArgs e)
        {

        }

        private void OnHealingUsage(object sender, EventArgs e)
        {

        }

        private void OnBattleEvents(object sender, EventArgs e)
        {

        }
    }
}
