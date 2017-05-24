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
	public partial class SettingsPage : ContentPage
	{
        ItemDataAccess data;
		public SettingsPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            data = new ItemDataAccess();
        }
        private void OnUseServerItems(object sender, EventArgs e)
        {
            if (ItemsFromServerSwitch.IsToggled)
            {
                RandomResultsSwitch.IsEnabled = true;
                SuperResultsSwitch.IsEnabled = true;
                Application.Current.Properties["ServerItems"] = true;
                data.GetAPIItems((bool)Application.Current.Properties["RandomizeItems"], (bool)Application.Current.Properties["SuperItems"]);
            }
            else
            {
                RandomResultsSwitch.IsEnabled = false;
                SuperResultsSwitch.IsEnabled = false;
                Application.Current.Properties["ServerItems"] = false;
                data.DeleteAllItems();
            }
        }

        private void OnRandomResults(object sender, EventArgs e)
        {
            if (RandomResultsSwitch.IsToggled)
                Application.Current.Properties["RandomizeItems"] = true;
            else
                Application.Current.Properties["RandomizeItems"] = false;
            data.GetAPIItems((bool)Application.Current.Properties["RandomizeItems"], (bool)Application.Current.Properties["SuperItems"]);
        }

        private void OnSuperResults(object sender, EventArgs e)
        {
            if (SuperResultsSwitch.IsToggled)
                Application.Current.Properties["SuperItems"] = true;
            else
                Application.Current.Properties["SuperItems"] = false;
            data.GetAPIItems((bool)Application.Current.Properties["RandomizeItems"], (bool)Application.Current.Properties["SuperItems"]);
        }

        private void OnCriticalSwitch(object sender, EventArgs e)
        {
            if (CriticalSwitch.IsToggled)
                Application.Current.Properties["OnlyCrit"]= true;
            else
                Application.Current.Properties["OnlyCrit"] = false;
        }

        private void OnItemUsage(object sender, EventArgs e)
        {
            if (ItemsUsageSwitch.IsToggled)
                Application.Current.Properties["ItemUsage"] = true;
            else
                Application.Current.Properties["ItemUsage"] = false;
        }

        private void OnMagicUsage(object sender, EventArgs e)
        {
            if (MagicUsageSwitch.IsToggled)
                Application.Current.Properties["MagicAllowed"] = true;
            else
                Application.Current.Properties["MagicAllowed"] = false;
        }

        private void OnHealingUsage(object sender, EventArgs e)
        {
            if (HealingUsageSwitch.IsToggled)
                Application.Current.Properties["HealingAllowed"] = true;
            else
                Application.Current.Properties["HealingAllowed"] = false;
        }

        private void OnBattleEvents(object sender, EventArgs e)
        {
            if (BattleEventsSwitch.IsToggled)
                Application.Current.Properties["BattleEventsAllowed"] = true;
            else
                Application.Current.Properties["BattleEventsAllowed"] = false;
        }
    }
}
