using WebAPI.Models;

namespace WebAPI.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetUserByIdAsync(long id);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(long id);
}