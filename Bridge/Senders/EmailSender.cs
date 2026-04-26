using Bridge.Interfaces;

namespace Bridge.Senders;

public class EmailSender : INotificationSender
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine($"[EMAIL] Para: {recipient} | Mensagem: {message}");
    }
}