using Bridge.Interfaces;

namespace Bridge.Notifications;

public class UrgentNotification : Notification
{
    public UrgentNotification(INotificationSender sender) : base(sender)
    {
    }

    public override void Notify(string recipient, string message)
    {
        _sender.Send(recipient, message);
    }
}