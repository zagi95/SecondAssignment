using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Mapper;

public static class UserMapper
{
    public static UserRecordDto ToUserRecordDto(User user)
    {
        return new UserRecordDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            
            LoginRecordDto = user.LoginRecords
                .OrderByDescending(lr => lr.LoginDate)
                .Select(lr => new LoginRecordDto
                {
                    LoginDate = lr.LoginDate
                })
                .ToList()
        };
    }
    public static User FromUserRegistrationDto(UserRegistrationDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Username = dto.Username,
            Password = dto.Password,
            LoginRecords = new List<LoginRecord>()
        };
    }

    public static User FromUserRegistrationDto(long id, UserRegistrationDto dto)
    {
        return new User
        {
            Id = id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Username = dto.Username,
            Password = dto.Password,
            LoginRecords = new List<LoginRecord>()
        };
    }
}