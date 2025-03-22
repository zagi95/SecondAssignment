using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Repositories;

public class LoginRecordRepository :  ILoginRecordRepository
{
    private readonly WebApiDbContext _dbContext;

    public LoginRecordRepository(WebApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<LoginRecord>> GetAllAsync()
    {
        return await _dbContext.LoginRecords
            .Include(r => r.User)
            .ToListAsync();
    }

    public async Task AddAsync(LoginRecord loginRecord)
    {
        _dbContext.LoginRecords.Add(loginRecord);
        await _dbContext.SaveChangesAsync();
    }   
}