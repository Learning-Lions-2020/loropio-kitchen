using LoropioKitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoropioKitchen.Data.DbContexts;

public class LoropioKitchenDbContext : DbContext
{
    public LoropioKitchenDbContext(DbContextOptions<LoropioKitchenDbContext> options)
    : base(options)
    {
    }


    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Email).HasMaxLength(320).IsRequired();
            entity.Property(u => u.PhoneNumber).HasMaxLength(50).IsRequired();
            entity.Property(u => u.Name).HasMaxLength(200).IsRequired();
            entity.Property(u => u.Role).HasConversion<string>();
            entity.Property(u => u.Status).HasConversion<string>();

            entity.HasIndex(u => u.Email).IsUnique();
            entity.HasIndex(u => u.PhoneNumber).IsUnique();
        });
    }
}
