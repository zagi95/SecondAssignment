using BlazorClient.Models;
using BlazorClient.Services.Interface;

namespace BlazorClient.Services;

public class LoginRecordService
{
    private IHttpService  _httpService;

    public LoginRecordService(IHttpService httpService)
    {
        _httpService = httpService;
    }
    
    public async Task<List<LoginRecord>?> GetLoginRecords()
    {
        Console.WriteLine("LoginUserService::GetLoginRecords");
        return await _httpService.Get<List<LoginRecord>>("http://localhost:5183/api/login_records");
    }
}