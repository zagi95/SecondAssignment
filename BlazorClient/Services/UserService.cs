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
        return await _httpService.Get<List<User>>("api/user");
    }

    public async Task<List<User>> GetUsersTestAsync()
    {
        return new List<User>
        {
            new()
            {
                FirstName = "ime1",
                LastName = "prezime1",
                Username = "user1",
                LoginRecords = new List<LoginRecord>
                {
                    new()
                    {
                        LoginDate = new DateTime(1995, 2, 22)
                    }
                }
            }
        };
    }
}