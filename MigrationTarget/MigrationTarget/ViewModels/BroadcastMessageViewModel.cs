using CommunityToolkit.Mvvm.Messaging;
using MigrationTarget.Messages;

namespace MigrationTarget.ViewModels
{
    public class BroadcastMessageViewModel
    {
        public Command ActionCommand
        {
            get
            { 
                return new Command(() =>
                { 
                    WeakReferenceMessenger.Default.Send(new ActionExecutedMessage(true));
                });
            }
        }
    }
}
