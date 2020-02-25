using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fiap.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeoLocationPage : ContentPage
    {
        public GeoLocationPage()
        {
            InitializeComponent();
            GetMyLocation();
        }

        private async void GetMyLocation()
        {
            IGeolocator geoLocator = CrossGeolocator.Current;
            geoLocator.DesiredAccuracy = 50;

            Position position = await geoLocator.GetPositionAsync(timeout: TimeSpan.FromSeconds(20));
            lblLatitude.Text = position.Latitude.ToString("0:0.0000000");
            lblLongitude.Text = position.Longitude.ToString("0:0.0000000");
        }
    }
}