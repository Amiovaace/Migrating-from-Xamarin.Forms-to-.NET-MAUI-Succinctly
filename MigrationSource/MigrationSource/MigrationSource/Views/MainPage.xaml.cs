using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Syncfusion.Pdf.Graphics.Images.Decoder;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigrationSource.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LinkGesture_Tapped(object sender,
            EventArgs e)
        {
            await DisplayAlert("Info",
                "You tapped the link!", "OK");
            Analytics.TrackEvent("Link tapped");
        }

        private void BatteryStatusButton_Clicked(object sender,
            EventArgs e)
        {
            try
            {
                BatteryStatusLabel.Text =
            $"Charge level: {Battery.ChargeLevel}";
                Analytics.TrackEvent("Battery status checked.");
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }
    }
}