using LoropioKitchen.Domain.Entities;

namespace LoropioKitchen.Application.Contracts;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByPhoneAsync(string phoneNumber);
    Task AddAsync(User user);
    Task SaveChangesAsync();
}
