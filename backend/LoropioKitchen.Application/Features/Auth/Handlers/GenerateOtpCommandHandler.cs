using LoropioKitchen.Application.Contracts;
using LoropioKitchen.Application.Features.Auth.Commands;
using LoropioKitchen.Domain.Entities;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace LoropioKitchen.Application.Features.Auth.Handlers;

public class GenerateOtpCommandHandler : IRequestHandler<GenerateOtpCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IOtpRepository _otpRepository;
    private readonly INotificationService _notificationService;

    public GenerateOtpCommandHandler(
        IUserRepository userRepository,
        IOtpRepository otpRepository,
        INotificationService notificationService)
    {
        _userRepository = userRepository;
        _otpRepository = otpRepository;
        _notificationService = notificationService;
    }

    public async Task<bool> Handle(GenerateOtpCommand request, CancellationToken cancellationToken)
    {
        var emailOrPhone = request.EmailOrPhone.Trim();

        var user = emailOrPhone.Contains("@")
            ? await _userRepository.GetByEmailAsync(emailOrPhone)
            : await _userRepository.GetByPhoneAsync(emailOrPhone);

        if (user is null)
            throw new InvalidOperationException("User not found.");

        var otp = new Random().Next(100000, 999999).ToString();

        using var sha256 = SHA256.Create();
        var hash = Convert.ToBase64String(
            sha256.ComputeHash(Encoding.UTF8.GetBytes(otp)));

        var otpCode = new OtpCode(user.Id, hash, DateTime.UtcNow.AddMinutes(5));
        await _otpRepository.AddAsync(otpCode);
        await _otpRepository.SaveChangesAsync();

        if (emailOrPhone.Contains("@"))
            await _notificationService.SendEmailAsync(user.Email, "Your OTP Code", $"Your OTP is {otp}");
        else
            await _notificationService.SendSmsAsync(user.PhoneNumber, $"Your OTP is {otp}");

        return true;
    }
}

