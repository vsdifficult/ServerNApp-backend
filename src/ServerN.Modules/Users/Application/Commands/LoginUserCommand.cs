using SeverN.SharedKernel.Application;

namespace SeverN.Modules.Users.Application.Commands;

public record LoginUserCommand(
    string Email, 
    string Password) : ICommand<AuthenticationResultDto>;

public record AuthenticationResultDto(Guid userId, string Token);
