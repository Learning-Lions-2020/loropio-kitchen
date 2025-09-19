using LoropioKitchen.Application.Contracts;
using LoropioKitchen.Data.DbContexts;
using LoropioKitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoropioKitchen.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LoropioKitchenDbContext _context;

    public UserRepository(LoropioKitchenDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByPhoneAsync(string phoneNumber)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

}
