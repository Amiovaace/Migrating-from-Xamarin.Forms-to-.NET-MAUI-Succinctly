using CommunityToolkit.Mvvm.Messaging;
using MigrationTarget.Messages;
using MigrationTarget.ViewModels;

namespace MigrationTarget.Views;

public partial class BroadcastMessagePage : ContentPage
{
    private BroadcastMessageViewModel ViewModel { get; set; }
    public BroadcastMessagePage()
    {
        InitializeComponent();
        ViewModel = new BroadcastMessageViewModel();
        BindingContext = ViewModel;
        WeakReferenceMessenger.Default.Register<ActionExecutedMessage>(this, ButtonTapped);
    }

    private async void ButtonTapped(object recipient, ActionExecutedMessage message)
    {
        await DisplayAlert("Info", "You clicked the button!", "OK");
    }

    protected override void OnDisappearing()
    {
        WeakReferenceMessenger.Default.Unregister<ActionExecutedMessage>(this);
        base.OnDisappearing();
    }
}