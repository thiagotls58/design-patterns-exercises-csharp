// See https://aka.ms/new-console-template for more information

using Bridge.Interfaces;
using Bridge.Notifications;
using Bridge.Senders;

Console.WriteLine("=== NotifyHub ===");

INotificationSender emailSender = new EmailSender();
INotificationSender smsSender = new SmsSender();
INotificationSender pushSender = new PushSender();

// Simple Notification
Notification notification = new SimpleNotification(emailSender);
SendNotification(notification, "Thiago", "Hello, this is a simple notification");

notification = new  SimpleNotification(smsSender);
SendNotification(notification, "Thiago", "Hello, this is a simple notification");

notification = new SimpleNotification(pushSender);
SendNotification(notification, "Thiago", "Hello, this is a simple notification");


// Urgent Notification
notification = new UrgentNotification(emailSender);
SendNotification(notification, "Thiago", "Hello, this is a urgent notification!!!");

notification = new  UrgentNotification(smsSender);
SendNotification(notification, "Thiago", "Hello, this is a urgent notification!!!");

notification = new  UrgentNotification(pushSender);
SendNotification(notification, "Thiago", "Hello, this is a urgent notification!!!");

void SendNotification(Notification notification, string recipient, string message)
{
    notification.Notify(recipient, message);
}