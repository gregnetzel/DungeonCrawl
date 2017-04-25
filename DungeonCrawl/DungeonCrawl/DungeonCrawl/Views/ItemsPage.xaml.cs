using DungeonCrawl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DungeonCrawl.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
        public ObservableCollection<Item> ItemsList = new ObservableCollection<Item>();

        public ItemsPage()
        {
            InitializeComponent();

            Title = "Items";

            ItemsView.ItemsSource = ItemsList;
            populateItems();
            ItemsView.ItemSelected += async (sender, e) =>
            {
                var item = e.SelectedItem as Item;
                if (e.SelectedItem == null) return;
                await Navigation.PushAsync(new ItemsDetails(item));
            };

        }

        void populateItems()
        {
            ItemsList.Add(new Item
            {
                Name = "Elucidator (Kirito)",
                Type = "Sword",
                Description = "Kirito's primary weapon. ",
                StrValue = 9,
                DexValue = 4,
                HPValue = 0,
                SpdValue = 4,
                Image = "kiritosword.png"
            });
            ItemsList.Add(new Item
            {
                Name = "Lambent Light (Asuna)",
                Type = "Sword",
                Description = "Asuna's primary weapon.",
                StrValue = 9,
                DexValue = 4,
                HPValue = 0,
                SpdValue = 4,
                Image = "asunasword.png"
            });
            ItemsList.Add(new Item
            {
                Name = "PGM Ultima Ratio Hecate II (Sinon)",
                Type = "Sniper",
                Description = "Sinon's primary weapon.",
                StrValue = 15,
                DexValue = 8,
                HPValue = 0,
                SpdValue = 0,
                Image = "sinongun.png"
            });
            ItemsList.Add(new Item
            {
                Name = "Absolute Sword (Yuuki)",
                Type = "Sword",
                Description = "Yuuki's primary weapon",
                StrValue = 10,
                DexValue = 4,
                HPValue = 0,
                SpdValue = 4,
                Image = "yuukisword.png"
            });

        }
    }
}
