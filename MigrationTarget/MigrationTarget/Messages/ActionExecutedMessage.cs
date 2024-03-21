using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MigrationTarget.Messages
{
    public class ActionExecutedMessage : ValueChangedMessage<bool>
    {
        public ActionExecutedMessage(bool value) : base(value)
        {

        }
    }
}
