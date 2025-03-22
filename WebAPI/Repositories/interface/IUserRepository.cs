using WebAPI.Models;

namespace WebAPI.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetUserByIdAsync(long id);
    Task<User> AddUserAsync(User user);
    Task<User?> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(long id);
}