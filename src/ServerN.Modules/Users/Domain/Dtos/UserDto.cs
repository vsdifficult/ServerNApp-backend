
using SeverN.Modules.Users.Domain.Enums;
using SeverN.SharedKernel.Domain;

namespace SeverN.Modules.Users.Domain.Dtos;

public record UserDto
{
    public Guid Id { get; init; }

    public DateTime CreateAt { get; init; }

    public DateTime UpdateAt { get; init; }

    public BaseStatus Status { get; init; }

    public string UserName { get; init; }

    public string PasswordHash { get; init; }

    public string Email { get; init; } 
    
    public Role UserRole { get; init; }

    public string Code { get; init; }

    public bool IsVerify { get; init; }

    public bool IsDeleted { get; init; }

    public decimal Balance { get; init; }
}