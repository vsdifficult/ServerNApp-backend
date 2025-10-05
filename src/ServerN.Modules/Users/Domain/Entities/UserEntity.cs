
using SeverN.Modules.Users.Domain.Enums;
using SeverN.SharedKernel.Domain;

namespace SeverN.Modules.Users.Domain.Entities;

public class UserDto : BaseEntity
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; } 
    
    public Role UserRole { get; set; } 
}