using DungeonCrawl.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DungeonCrawl
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();

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
