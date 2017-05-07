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
        public EditItemDetails()
        {
            InitializeComponent();
        }
        public EditItemDetails(Item item)
        {
            InitializeComponent();

            this.Title = item.Name;

            ImageXAML.Source = item.Image;

            DetailsXAML.Text = $" Description: {item.Description} \n\n" +
                $" Str: {item.StrValue}\n Dex: {item.DexValue}\n Spd: {item.SpdValue}\n HP: {item.HPValue}";
            HPXAML.Text = ""+item.HPValue;
            StrXAML.Text = "" + item.StrValue;
            SpeedXAML.Text = "" + item.SpdValue;
            DextXAML.Text = "" + item.DexValue;
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            //save to db
        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            //remove from db
            await Navigation.PopAsync();
        }
    }
}
