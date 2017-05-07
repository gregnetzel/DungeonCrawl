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
        private ItemDataAccess dataAccess;
        public ItemsPage()
        {
            InitializeComponent();
            this.dataAccess = new ItemDataAccess();

            Title = "Items";

            ItemsView.ItemsSource = ItemsList;
            PopulateItems();
        }

        void PopulateItems()
        {
            var templist = dataAccess.GetItems();
            ItemsList.Clear();
            foreach (Item i in templist)
            {
                ItemsList.Add(i);
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulateItems();
        }
        async void OnItemClick(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Item;
            await Navigation.PushAsync(new EditItemDetails(item));
        }
        async void OnAddClicked(object sender, SelectedItemChangedEventArgs e)
        {
            Item item = dataAccess.AddNewItem();
            await Navigation.PushAsync(new EditItemDetails(item));
        }
    }
}
