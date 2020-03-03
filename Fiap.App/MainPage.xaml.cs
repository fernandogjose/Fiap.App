using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Fiap.App
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TapGeoLocation_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GeoLocationPage());
        }

        private void TapPhoto_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PhotoPage());
        }

        private void TapMongoDb_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MongoDbPage());
        }

        private void TapApi_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ApiPage());
        }

        private void TapCalculadora_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CalculadoraPage());
        }

        private void TapImc_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImcPage());
        }
    }
}
