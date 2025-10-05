
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using SeverN.Modules.Users.Domain.Entities; 
using SeverN.Modules.Users.Domain.Dtos;
using SeverN.Modules.Users.Application.Repository;

namespace SeverN.Modules.Users.Infrastructure.Repositories; 

public class UserRepository : IUserRepository
{
    private readonly UsersDbContext _dbContext;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(UsersDbContext dbContext, ILogger<UserRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var userEntity = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        return ToDto(userEntity);
    }

    public async Task<int> GetAllUsersValue()
    {
        return await _dbContext.Users.CountAsync(); 
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        try
        {
            var entities = await _dbContext.Users.AsNoTracking().ToListAsync();
            return entities.Select(ToDto).Where(dto => dto != null)!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving all users");
            throw;
        }
    }

    public async Task<UserDto?> GetByEmailAsync(string email)
    {
        var userEntity = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        return ToDto(userEntity);
    }
    public async Task<Guid> CreateAsync(UserDto body)
    {
        try
        {
            var entity = ToEntity(body);
            entity.Id = Guid.NewGuid();
            entity.CreateAt = DateTime.UtcNow;

            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating user {UserName}", body.UserName);
            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {

        try
        {
            var entity = await _dbContext.Users.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            entity.IsDeleted = true;
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting user with ID {Id}", id);
            throw;
        }
    }

    public async Task<bool> UpdateAsync(UserDto body)
    {
        try
        {
            var existingUser = await _dbContext.Users.FindAsync(body.Id);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.UserName = body.UserName;
            existingUser.Email = body.Email;
            existingUser.UpdateAt = DateTime.UtcNow;
            existingUser.Status = body.Status;
            existingUser.IsVerify = body.IsVerify;
            existingUser.UserRole = body.UserRole;

            _dbContext.Users.Update(existingUser);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user with ID {Id}", body.Id);
            throw;
        }
    }

    public async Task<bool> UpdateBalanceAsync(string email, decimal newBalance)
    {
        try
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                _logger.LogError("User with email {email} not found", email);
                return false;
            }

            user.Balance = newBalance;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating balance for user with email {email}", email);
            throw;
        }
    }

    private UserDto? ToDto(UserEntity? body)
    {
        return new UserDto
        {
            Id = body.Id,
            CreateAt = body.CreateAt,
            UpdateAt = body.UpdateAt,
            Status = body.Status,
            Email = body.Email,
            PasswordHash = body.PasswordHash,
            UserName = body.UserName,
            UserRole = body.UserRole,
            Code = body.Code,
            IsVerify = body.IsVerify,
            IsDeleted = body.IsDeleted,
            Balance = body.Balance
        };
    }

    private UserEntity ToEntity(UserDto body)
    {
        return new UserEntity
        {
            Id = body.Id,
            CreateAt = body.CreateAt,
            UpdateAt = body.UpdateAt,
            Status = body.Status,
            Email = body.Email,
            PasswordHash = body.PasswordHash,
            UserName = body.UserName,
            UserRole = body.UserRole,
            Code = body.Code,
            IsVerify = body.IsVerify,
            IsDeleted = body.IsDeleted,
            Balance = body.Balance
        };
    }
}