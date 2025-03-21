using WebAPI.Models;

namespace WebAPI.Repositories;

public class UserRepository :  IUserRepository
{
    private static List<User> _users = new List<User>
    {
        new User { Id = 1, FirstName = "mate", LastName = "miso", Username = "kovac", Password = "1234" },
        new User { Id = 2, FirstName = "mate2", LastName = "miso2", Username = "kovac2", Password = "12345" },
    };
    private readonly WebApiDbContext _dbContext;

    public UserRepository(WebApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAllAsync()
    {
        Console.WriteLine("get all users");
        return await Task.FromResult(_users);
    }

    public async Task<User?> GetUserByIdAsync(long id)
    {
        return await Task.FromResult(_users.SingleOrDefault(user => user.Id == id));
    }

    public async Task AddUserAsync(User user)
    {
        user.Id = _users.Max(user => user.Id) + 1;
        _users.Add(user);
        await Task.CompletedTask;
    }

    public Task UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUserAsync(long id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return false;
        _users.Remove(user);
        return await Task.FromResult(true);
    }
}