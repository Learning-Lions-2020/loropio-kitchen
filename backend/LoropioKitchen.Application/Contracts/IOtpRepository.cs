using LoropioKitchen.Domain.Entities;

namespace LoropioKitchen.Application.Contracts;

public interface IOtpRepository
{
    Task<OtpCode?> GetByIdAsync(Guid id);
    Task<OtpCode?> GetLatestByUserIdAsync(Guid userId);
    Task AddAsync(OtpCode otp);
    Task SaveChangesAsync();
}
