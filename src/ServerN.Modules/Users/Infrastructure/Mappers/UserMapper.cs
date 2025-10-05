
using SeverN.Modules.Users.Application.Commands;
using SeverN.Modules.Users.Domain.Dtos;
using SeverN.Modules.Users.Domain.Entities;
using SeverN.Modules.Users.Domain.Enums;
using DevOne.Security.Cryptography.BCrypt;

namespace SeverN.Modules.Users.Infrastructure.Mappers;

public class UserMapper
{
    public UserDto RegisterUser(CreateUserCommand body)
    {
        return new UserDto
        {
            Id = Guid.NewGuid(),
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            Status = SharedKernel.Domain.BaseStatus.Active,
            UserName = body.UserName,
            PasswordHash = body.Password,
            Email = body.Email,
            UserRole = body.UserRole,
            Code = new Random().Next(1000, 9999).ToString(),
            IsVerify = false,
            IsDeleted = false,
            Balance = 0
        };
    } 
    
    
}