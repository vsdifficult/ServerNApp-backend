using SeverN.Modules.Users.Application.Repository;
using SeverN.Modules.Users.Application.Commands;


using MediatR;
using DevOne.Security.Cryptography.BCrypt;
using SeverN.Modules.Users.Domain.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace SeverN.Modules.Users.Infrastructure.CommandHandler;

internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthenticationResultDto>
{
    private readonly IUserRepository _userRepository;
    public LoginUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> GenerateTokenAsync(Guid userId, Role role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("SuperSecretKeyForDevPurposesOnly1234567890!");

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userId.ToString()),
            new(ClaimTypes.Role, role.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(64),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<AuthenticationResultDto> Handle(LoginUserCommand loginUser, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(loginUser.Email) ?? throw new Exception("User not found");

        if (!BCryptHelper.CheckPassword(loginUser.Password, user.PasswordHash)) { throw new Exception("Invalid password"); }

        var token = await GenerateTokenAsync(user.Id, user.UserRole);

        return new AuthenticationResultDto(user.Id, token); 
    }
}