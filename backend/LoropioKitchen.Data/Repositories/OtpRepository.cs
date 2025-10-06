using LoropioKitchen.Application.Contracts;
using LoropioKitchen.Data.DbContexts;
using LoropioKitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoropioKitchen.Data.Repositories;

public class OtpRepository : IOtpRepository
{
    private readonly LoropioKitchenDbContext _context;

    public OtpRepository(LoropioKitchenDbContext context)
    {
        _context = context;
    }

    public async Task<OtpCode?> GetByIdAsync(Guid id)
    {
        return await _context.OtpCodes.FindAsync(id);
    }

    public async Task<OtpCode?> GetLatestByUserIdAsync(Guid userId)
    {
        return await _context.OtpCodes
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.Expiry)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(OtpCode otp)
    {
        await _context.OtpCodes.AddAsync(otp);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
