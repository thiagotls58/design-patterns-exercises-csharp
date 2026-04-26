using Bridge.Interfaces;

namespace Bridge.Senders;

public class SmsSender : INotificationSender
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine($"[SMS] Para: {recipient} | Mensagem: {message}");
    }
}