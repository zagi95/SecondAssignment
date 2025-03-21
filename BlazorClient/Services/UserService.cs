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

    public async Task AddUser(UserRegistration userRegistration)
    {
        await _httpService.Post("http://localhost:5183/api/users", userRegistration);
    }

    public async Task UpdateUser(UserRegistration userRegistration)
    {
        await _httpService.Post("http://localhost:5183/api/users", userRegistration);
    }
}