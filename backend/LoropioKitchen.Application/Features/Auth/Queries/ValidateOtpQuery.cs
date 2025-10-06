using MediatR;

namespace LoropioKitchen.Application.Features.Auth.Queries;

public record ValidateOtpQuery(string EmailOrPhone, string OtpCode) : IRequest<bool>;
