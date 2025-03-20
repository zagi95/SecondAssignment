using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetUsersAsync() => await _userRepository.GetAllAsync();
    
    public async Task<User?> GetUserByIdAsync(int id) => await _userRepository.GetUserByIdAsync(id);

    public async Task AddUserAsync(User user) => await _userRepository.AddUserAsync(user);

    public async Task<bool> DeleteUserAsync(int id) => await _userRepository.DeleteUserAsync(id);
}