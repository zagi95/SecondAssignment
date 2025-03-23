using BlazorClient.Models;
using BlazorClient.Services.Interface;

namespace BlazorClient.Services;

public class UserService
{
    private IHttpService  _httpService;

    public UserService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<List<User>?> GetUsers()
    {
        return await _httpService.Get<List<User>>("http://localhost:5183/api/users");
    }

    public async Task<User?> AddUser(UserRegistration userRegistration)
    {
        return await _httpService.Post<UserRegistration, User>
            ("http://localhost:5183/api/auth/register", userRegistration);
    }

    public async Task UpdateUser(UserUpdate userUpdate)
    {
        await _httpService.Put($"http://localhost:5183/api/users/{userUpdate.Id}", userUpdate);
    }

    public async Task<bool> DeleteUser(long userId)
    {
        return await _httpService.Delete($"http://localhost:5183/api/users/{userId}");
    }
    
    public async Task<LoginRecord?> LoginUser(UserLogin login, string userAgent)
    {
        var headers = new Dictionary<string, string>
        {
            { "User-Agent", userAgent }
        };
        return await _httpService.Post<UserLogin, LoginRecord>
            ("http://localhost:5183/api/auth/login", login, headers);
    }

}