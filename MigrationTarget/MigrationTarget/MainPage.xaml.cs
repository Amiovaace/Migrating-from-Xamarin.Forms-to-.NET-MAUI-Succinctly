using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Maui.Platform;
using MigrationTarget.Views;

namespace MigrationTarget
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ModifyEntry();
        }

        private async void LinkGesture_Tapped(object sender,
                EventArgs e)
        {
            await DisplayAlert("Info",
                "You tapped the link!", "OK");
            Analytics.TrackEvent("Link tapped in .NET MAUI");
        }

        private void BatteryStatusButton_Clicked(object sender,
            EventArgs e)
        {
            try
            {
                BatteryStatusLabel.Text =
            $"Charge level: {Battery.ChargeLevel}";
                Analytics.TrackEvent("Battery status checked in .NET MAUI.");
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex); 
            }
        }

        private void ColorHandling()
        {
            var black = Color.FromArgb("#000000");
        }

        void ModifyEntry()
        {
            Microsoft.Maui.Handlers.EntryHandler.
                Mapper.AppendToMapping("AutoSelectOnFocus", (handler, view) =>
                {
                    if (view is AutoSelectEntry)
                    {
#if ANDROID
                        handler.PlatformView.SetSelectAllOnFocus(true);
#elif iOS
            handler.PlatformView.PerformSelector(new ObjCRuntime
                  .Selector("selectAll"), null, 0.0f);

#elif WINDOWS
            handler.PlatformView.SelectAll();
#endif
                    }
                });
        }

        private void Entry_HandlerChanging(object sender, HandlerChangingEventArgs e)
        {
            if (e.OldHandler != null)
            {
#if ANDROID
                (e.OldHandler.PlatformView as Android.Views.View).FocusChange -= OnFocusChange;
#endif
            }
        }

        private void Entry_HandlerChanged(object sender, EventArgs e)
        {
#if ANDROID
            ((sender as Entry).Handler.PlatformView as Android.Views.View).FocusChange += OnFocusChange;
#endif
        }


#if ANDROID
        void OnFocusChange(object sender, EventArgs e)
        {
            var nativeView = sender as AndroidX.AppCompat.Widget.AppCompatEditText;

            if (nativeView.IsFocused)
                nativeView.SetBackgroundColor(Colors.LightGray.ToPlatform());
            else
                nativeView.SetBackgroundColor(Colors.Transparent.ToPlatform());
        }
#endif  
    }
}
