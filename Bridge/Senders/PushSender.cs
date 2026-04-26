using Bridge.Interfaces;

namespace Bridge.Senders;

public class PushSender : INotificationSender
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine($"[PUSH] Para: {recipient} | Mensagem: {message}");
    }
}