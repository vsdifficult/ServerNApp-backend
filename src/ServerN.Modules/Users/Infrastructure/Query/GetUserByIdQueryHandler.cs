
using SeverN.Modules.Users.Application.Repository;
using SeverN.Modules.Users.Infrastructure.Mappers;

using MediatR;
using SeverN.Modules.Users.Application.Queries;
using SeverN.Modules.Users.Domain.Dtos;

namespace SeverN.Modules.Users.Infrastructure.QueryHandler;

internal class GetUserByIdQueryHandler: IRequestHandler<GetByIdUserQuery, UserDto?>
{
    private readonly IUserRepository _userRepository;
    private readonly UserMapper _userMapper;

    public GetUserByIdQueryHandler(
        IUserRepository userRepository,
        UserMapper userMapper
        )
    {
        _userRepository = userRepository;
        _userMapper = userMapper;
    }

    public async Task<UserDto?> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByIdAsync(request.UserId)
                        ?? throw new Exception("User not found");
    }
}