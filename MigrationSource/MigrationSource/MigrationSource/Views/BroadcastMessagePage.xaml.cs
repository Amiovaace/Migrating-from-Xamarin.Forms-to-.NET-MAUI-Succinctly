using MigrationSource.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigrationSource.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BroadcastMessagePage : ContentPage
    {
        private BroadcastMessageViewModel ViewModel { get; set; }
        public BroadcastMessagePage()
        {
            InitializeComponent();
            ViewModel = new BroadcastMessageViewModel();
            BindingContext = ViewModel;

            MessagingCenter.Subscribe<BroadcastMessageViewModel>(this, "ButtonTapped", ShowAlert);
        }

        private async void ShowAlert(BroadcastMessageViewModel model)
        {
            await DisplayAlert("Info", "You clicked the button!", "OK");
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<BroadcastMessageViewModel>(this, "ButtonTapped");
            base.OnDisappearing();
        }
    }
}