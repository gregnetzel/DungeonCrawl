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
	public partial class ItemsDetails : ContentPage
	{
		public ItemsDetails ()
		{
			InitializeComponent ();
		}
        public ItemsDetails(Item item)
        {
            InitializeComponent();

            Title = item.Name;            

            DetailsXAML.Text = $" Str: {item.StrValue}\n Dex: {item.DexValue}\n Spd: {item.SpdValue}\n HP: {item.HPValue}";

        }
    }
}
