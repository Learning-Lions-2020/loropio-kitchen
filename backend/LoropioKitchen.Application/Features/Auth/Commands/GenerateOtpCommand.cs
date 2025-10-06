using MediatR;

namespace LoropioKitchen.Application.Features.Auth.Commands;

public record GenerateOtpCommand(string EmailOrPhone) : IRequest<bool>;
