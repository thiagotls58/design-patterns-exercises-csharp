using Bridge.Interfaces;

namespace Bridge.Notifications;

public abstract class Notification
{
    protected readonly INotificationSender _sender;

    protected Notification(INotificationSender sender)
    {
        _sender = sender;
    }
    
    public abstract void Notify(string recipient, string message);
}