using SeverN.Modules.Users.Application.Queries; 
using SeverN.Modules.Users.Application.Repository;
using SeverN.Modules.Users.Infrastructure.Mappers;

using MediatR;
using SeverN.Modules.Users.Domain.Dtos;

namespace SeverN.Modules.Users.Infrastructure.QueryHandler;

internal class GetUserByNameQueryHandler : IRequestHandler<GetByNameUserQuery, UserDto?>
{
    private readonly IUserRepository _userRepository;
    public GetUserByNameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> Handle(GetByNameUserQuery nameUserQuery, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByNameAsync(nameUserQuery.Name)
                ?? throw new Exception("User not found"); 
    }
}