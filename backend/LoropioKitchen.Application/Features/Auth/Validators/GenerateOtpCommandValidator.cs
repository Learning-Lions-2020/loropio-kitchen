using FluentValidation;
using LoropioKitchen.Application.Features.Auth.Commands;

namespace LoropioKitchen.Application.Features.Auth.Validators;

public class GenerateOtpCommandValidator : AbstractValidator<GenerateOtpCommand>
{
    public GenerateOtpCommandValidator()
    {
        RuleFor(x => x.EmailOrPhone).NotEmpty();
    }
}
