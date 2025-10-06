using LoropioKitchen.Application.Contracts;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace LoropioKitchen.Application.Services;

public class GmailEmailService : INotificationService
{
    private readonly IConfiguration _config;
    private readonly string _fromEmail;
    private readonly string _appPassword;

    public GmailEmailService(IConfiguration config)
    {
        _config = config;
        _fromEmail = _config["GmailSettings:FromEmail"]!;
        _appPassword = _config["GmailSettings:AppPassword"]!;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        using var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(_fromEmail, _appPassword)
        };

        using var message = new MailMessage(_fromEmail, to, subject, body)
        {
            IsBodyHtml = false
        };

        await client.SendMailAsync(message);
    }

    public Task SendSmsAsync(string phone, string message) => Task.CompletedTask;
}
