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


            entity.Property(u => u.Email).HasMaxLength(320);
            entity.Property(u => u.PhoneNumber).HasMaxLength(50);
            entity.Property(u => u.Name).HasMaxLength(200);


            entity.HasIndex(u => u.PhoneNumber).IsUnique(false);
            entity.HasIndex(u => u.Email).IsUnique(false);
        });
    }
}
