
using SeverN.Modules.Users.Domain.Enums;
using SeverN.SharedKernel.Domain;

namespace SeverN.Modules.Users.Domain.Dtos;

public record UserDto
{
    public Guid Id { get; init; }

    public DateTime CreateAt { get; init; }

    public DateTime UpdateAt { get; init; }

    public BaseStatus BStatus { get; init; }

    public string UserName { get; init; }

    public string Password { get; init; }

    public string Email { get; init; } 
    
    public Role UserRole { get; init; } 
}