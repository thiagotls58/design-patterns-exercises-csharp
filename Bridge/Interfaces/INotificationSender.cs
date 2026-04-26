namespace Bridge.Interfaces;

public interface INotificationSender
{
    void Send(string recipient, string message);
}