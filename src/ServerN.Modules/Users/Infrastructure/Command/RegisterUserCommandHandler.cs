
using SeverN.Modules.Users.Application.Commands; 
using SeverN.Modules.Users.Application.Repository;
using SeverN.Modules.Users.Infrastructure.Mappers; 

using MediatR; 

namespace SeverN.Modules.Users.Infrastructure.CommandHandler;

internal class UserRegisterCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    private readonly UserMapper _userMapper;

    public UserRegisterCommandHandler(
        IUserRepository userRepository,
        UserMapper userMapper
        )
    {
        _userRepository = userRepository;
        _userMapper = userMapper;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.CreateAsync(_userMapper.RegisterUser(request));
    }
}