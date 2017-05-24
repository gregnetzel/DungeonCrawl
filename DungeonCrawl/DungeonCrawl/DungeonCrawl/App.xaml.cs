using DungeonCrawl.Views;
using DungeonCrawl.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DungeonCrawl
{
	public partial class App : Application
	{
        public bool OnlyCrit { get; set; }
		public bool HealingAllowed { get; set; }
		public bool MagicAllowed { get; set; }
		public bool BattleEventsAllowed { get; set; }
		public bool ItemUsage { get; set; }

        public static BattleEffectDataAccess BattleEffectManager;

        public App()
		{
			InitializeComponent();

            Application.Current.Properties["ServerItems"] = false;
            Application.Current.Properties["RandomizeItems"] = false;
            Application.Current.Properties["SuperItems"] = false;
			OnlyCrit = false;
			HealingAllowed = false;
			MagicAllowed = false;
			Application.Current.Properties["BattleEventsAllowed"] = false;
			ItemUsage = false;

            BattleEffectManager = new BattleEffectDataAccess();

            SetMainPage();
            
		}

		public static void SetMainPage()
		{
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new GamePage())
                    {
                        Title = "Game",
                    },
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Items",
                    },
                    new NavigationPage(new MonstersPage())
                    {
                        Title = "Monsters",
                    },
                    new NavigationPage(new SettingsPage())
                    {
                        Title = "Settings",
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                    },
                }
            };
        }
	}
}
