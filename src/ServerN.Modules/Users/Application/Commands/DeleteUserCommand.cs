using SeverN.Modules.Users.Domain.Enums;
using SeverN.SharedKernel.Application; 

namespace SeverN.Modules.Users.Application.Commands;

public record DeleteUserCommand
    (
    Guid UserId
    ) : ICommand<Guid>; 

