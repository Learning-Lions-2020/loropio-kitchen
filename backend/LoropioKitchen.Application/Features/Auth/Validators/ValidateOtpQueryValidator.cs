using FluentValidation;
using LoropioKitchen.Application.Features.Auth.Queries;

namespace LoropioKitchen.Application.Features.Auth.Validators;

public class ValidateOtpQueryValidator : AbstractValidator<ValidateOtpQuery>
{
    public ValidateOtpQueryValidator()
    {
        RuleFor(x => x.EmailOrPhone).NotEmpty();
        RuleFor(x => x.OtpCode)
            .NotEmpty()
            .Length(6).Matches("^[0-9]+$")
            .WithMessage("OTP must be a 6-digit number.");
    }
}
