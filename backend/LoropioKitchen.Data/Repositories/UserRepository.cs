using LoropioKitchen.Application.Contracts;
using LoropioKitchen.Data.DbContexts;
using LoropioKitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoropioKitchen.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LoropioKitchenDbContext _dbContext;


    public UserRepository(LoropioKitchenDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _dbContext.Users.AddAsync(user, cancellationToken);
    }


    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(email)) return null;
        var normalized = email.Trim();
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == normalized, cancellationToken);
    }


    public async Task<User?> GetByPhoneAsync(string phone, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(phone)) return null;
        var normalized = phone.Trim();
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == normalized, cancellationToken);
    }


    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FindAsync(new object[] { id }, cancellationToken);
    }


    public async Task<User?> GetByEmailOrPhoneAsync(string identifier, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(identifier)) return null;
        var trimmed = identifier.Trim();
        if (trimmed.Contains("@"))
        {
            return await GetByEmailAsync(trimmed, cancellationToken);
        }


        return await GetByPhoneAsync(trimmed, cancellationToken);
    }


    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }


    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
