namespace LoropioKitchen.Application.Contracts;

public interface INotificationService
{
    Task SendSmsAsync(string phone, string message);
    Task SendEmailAsync(string to, string subject, string body);
}
