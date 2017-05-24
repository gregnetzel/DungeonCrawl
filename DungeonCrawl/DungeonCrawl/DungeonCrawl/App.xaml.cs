using DungeonCrawl.Views;

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

        public App()
		{
			InitializeComponent();


			OnlyCrit = false;
			HealingAllowed = false;
			MagicAllowed = false;
			BattleEventsAllowed = false;
			ItemUsage = false;

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
                    new NavigationPage(new Settings())
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
