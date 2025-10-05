using Microsoft.EntityFrameworkCore;
using SeverN.Modules.Users.Domain.Entities;
using SeverN.Modules.Users.Infrastructure.Configurations;


namespace SeverN.Modules.Users.Infrastructure; 


public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

    public DbSet<UserEntity> Users { get; set; } = null!;

    // public DbSet<TransactionEntity> Transactions { get; set; } = null!; 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("servern");
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }
}