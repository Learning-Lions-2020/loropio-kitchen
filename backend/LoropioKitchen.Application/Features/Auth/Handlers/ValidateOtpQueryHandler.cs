using LoropioKitchen.Application.Contracts;
using LoropioKitchen.Application.Features.Auth.Queries;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace LoropioKitchen.Application.Features.Auth.Handlers;

public class ValidateOtpQueryHandler : IRequestHandler<ValidateOtpQuery, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IOtpRepository _otpRepository;

    public ValidateOtpQueryHandler(
        IUserRepository userRepository,
        IOtpRepository otpRepository)
    {
        _userRepository = userRepository;
        _otpRepository = otpRepository;
    }

    public async Task<bool> Handle(ValidateOtpQuery request, CancellationToken cancellationToken)
    {
        var emailOrPhone = request.EmailOrPhone.Trim();

        var user = emailOrPhone.Contains("@")
            ? await _userRepository.GetByEmailAsync(emailOrPhone)
            : await _userRepository.GetByPhoneAsync(emailOrPhone);

        if (user is null)
            throw new InvalidOperationException("User not found.");

        var otp = await _otpRepository.GetLatestByUserIdAsync(user.Id);

        if (otp is null) return false;

        using var sha256 = SHA256.Create();
        var hash = Convert.ToBase64String(
            sha256.ComputeHash(Encoding.UTF8.GetBytes(request.OtpCode)));

        if (!otp.IsValid(hash)) return false;

        otp.MarkAsUsed();
        await _otpRepository.SaveChangesAsync();

        return true;
    }
}

