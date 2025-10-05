using SeverN.Modules.Users.Domain.Enums;
using SeverN.SharedKernel.Application; 

namespace SeverN.Modules.Users.Application.Commands;

public record CreateUserCommand
    (
    string UserName,
    string Email,
    string Password,
    Role UserRole
    ) : ICommand<Guid>; 

