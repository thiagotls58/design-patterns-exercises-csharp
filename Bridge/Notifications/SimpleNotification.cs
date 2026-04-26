using Bridge.Interfaces;

namespace Bridge.Notifications;

public class SimpleNotification : Notification
{
    public SimpleNotification(INotificationSender sender) : base(sender)
    {
    }

    public override void Notify(string recipient, string message)
    {
        _sender.Send(recipient, message);
    }
}