using WebAPI.Models;

namespace WebAPI.Repositories;

public interface ILoginRecordRepository
{
    Task<List<LoginRecord>> GetAllAsync();
    Task AddAsync(LoginRecord loginRecord);
}