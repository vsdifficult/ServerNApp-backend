

using SeverN.Modules.Users.Application.Commands; 
using SeverN.Modules.Users.Application.Repository;
using SeverN.Modules.Users.Infrastructure.Mappers;  

using MediatR; 

namespace SeverN.Modules.Users.Infrastructure.CommandHandler;

internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository; 
    }
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.DeleteAsync(request.UserId); 
    }
}