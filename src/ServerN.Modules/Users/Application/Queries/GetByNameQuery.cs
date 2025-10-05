using SeverN.Modules.Users.Domain.Dtos;
using SeverN.Modules.Users.Domain.Enums;
using SeverN.SharedKernel.Application; 

namespace SeverN.Modules.Users.Application.Queries;

public record GetByNameUserQuery
    (
    string Name
    ) : IQuery<UserDto>; 

