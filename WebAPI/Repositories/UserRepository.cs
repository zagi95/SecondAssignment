using Microsoft.EntityFrameworkCore;
using WebAPI.Dtos;
using WebAPI.Models;
using WebAPI.Repositories.Projections;

namespace WebAPI.Repositories;

public class UserRepository :  IUserRepository
{
    private readonly WebApiDbContext _dbContext;

    public UserRepository(WebApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<UserProjection>> GetAllAsync()
    {
        return await _dbContext.Users
            .Select(u => new UserProjection
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                LoginCount = u.LoginRecords.Count
            })
            .ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(long id)
    {
        return await _dbContext.Users
            .Include(u => u.LoginRecords)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> AddUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> UpdateUserAsync(User user)
    {
        var existingUser = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == user.Id);

        if (existingUser == null)
            return null;
        
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Username = user.Username;
        existingUser.Password = user.Password;

        await _dbContext.SaveChangesAsync();
        return existingUser;
    }

    public async Task<bool> DeleteUserAsync(long id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user == null)
            return false;

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return true;   
    }
}