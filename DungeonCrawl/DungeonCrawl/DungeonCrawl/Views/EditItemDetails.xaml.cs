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
	public partial class EditItemDetails : ContentPage
	{
        private ItemDataAccess dataAccess;
        private Item tItem;
        public EditItemDetails()
        {
            InitializeComponent();
            dataAccess = new ItemDataAccess();
        }
        public EditItemDetails(Item item)
        {
            InitializeComponent();
            dataAccess = new ItemDataAccess();
            tItem = item;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = tItem;
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            dataAccess.SaveItem(tItem);
            await Navigation.PopAsync();
        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            dataAccess.DeleteItem(tItem);
            await Navigation.PopAsync();
        }
    }
}
