using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DungeonCrawl.Views
{
    public partial class StartUpPage : ContentPage
    {
        public StartUpPage()
        {
            InitializeComponent();

            StartUpButton.WidthRequest = Application.Current.MainPage.Width;
            StartUpButton.HeightRequest = Application.Current.MainPage.Height;
        }

        public void OnClicked(object sender, EventArgs e)
        {
            App.SetMainPage();
        }
    }
}
