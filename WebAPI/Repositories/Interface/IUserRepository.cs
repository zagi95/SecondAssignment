using WebAPI.Models;
using WebAPI.Repositories.Projections;

namespace WebAPI.Repositories;

public interface IUserRepository
{
    Task<List<UserProjection>> GetAllAsync();
    Task<User?> GetUserByIdAsync(long id);
    Task<User?> GetByUsernameAsync(string username);

    Task<User> AddUserAsync(User user);
    Task<User?> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(long id);
}