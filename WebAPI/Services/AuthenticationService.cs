using Microsoft.AspNetCore.Identity;
using WebAPI.Dtos;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services;

public class AuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly ILoginRecordRepository _loginRecordRepository;

    public AuthenticationService(IUserRepository userRepository, ILoginRecordRepository loginRecordRepository)
    {
        _userRepository = userRepository;
        _loginRecordRepository = loginRecordRepository;
    }

    public async Task<LoginRecordDto?> LoginAsync(UserLoginDto dto, string userAgent)
    {
        var user = await _userRepository.GetByUsernameAsync(dto.Username);
        if (user == null)
            return null;

        var isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
        if (!isValid)
            return null;

        var record = new LoginRecord
        {
            UserId = user.Id,
            LoginDate = DateTime.UtcNow,
            Browser = userAgent,
        };

        await _loginRecordRepository.AddAsync(record);

        return new LoginRecordDto
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            LoginDate = record.LoginDate,
            Browser = userAgent
        };
    }

    public async Task<UserRecordDto> RegisterAsync(UserRegistrationDto dto)
    {
        var newUser = new User
        {
            Username = dto.Username,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        var created = await _userRepository.AddUserAsync(newUser);

        return new UserRecordDto
        {
            Id = created.Id,
            FirstName = created.FirstName,
            LastName = created.LastName,
            LoginCount = 0
        };
    }
}