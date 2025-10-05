

using SeverN.Modules.Users.Domain.Dtos;
using SeverN.SharedKernel.Application;

namespace SeverN.Modules.Users.Application.Repository; 

public interface IUserRepository : IRepository<UserDto, Guid>
{
    Task<UserDto?> GetByEmailAsync(string email);
    Task<int> GetAllUsersValue();

    Task<bool> UpdateBalanceAsync(string email, decimal newBalance);
}