using Xamarin.Forms;

namespace MigrationSource.ViewModels
{
    public class BroadcastMessageViewModel
    {
        public Command ActionCommand
        {
            get
            {
                return new Command(() =>
                {
                    MessagingCenter.Send(this, "ButtonTapped");
                });
            }
        }
    }
}
