
using SeverN.Modules.Users.Domain.Enums;
using SeverN.SharedKernel.Domain;

namespace SeverN.Modules.Users.Domain.Entities;

public class UserEntity : BaseEntity
{
    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; } 

    public string Code { get; set; }

    public bool IsVerify { get; set; }

    public decimal Balance { get; set; }
    
    public Role UserRole { get; set; }
    public bool IsDeleted { get; set; }
}