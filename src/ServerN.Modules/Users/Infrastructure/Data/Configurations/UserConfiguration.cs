using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeverN.Modules.Users.Domain.Entities; 

namespace SeverN.Modules.Users.Infrastructure.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.CreateAt)
            .HasDefaultValueSql("NOW()");
        builder.Property(u => u.UpdateAt);
        builder.Property(u => u.Status);
        builder.Property(u => u.IsDeleted);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.UserRole)
            .IsRequired();

        builder.Property(u => u.Code)
            .IsRequired();

        builder.Property(u => u.IsVerify)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(u => u.Balance)
            .HasDefaultValue(0)
            .IsRequired(); 

        // builder.HasMany(u => u.Transactions)
        //     .WithOne(mt => mt.User)
        //     .HasForeignKey(mt => mt.BuyerId); 
            
        builder.HasIndex(u => u.Email); 
        
    }
}