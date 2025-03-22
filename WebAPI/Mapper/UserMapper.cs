using WebAPI.Dtos;
using WebAPI.Models;
using WebAPI.Repositories.Projections;

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
            LoginCount = user.LoginRecords.Count,
        };
    }

    public static UserRecordDto ToUserRecordDto(UserProjection user)
    {
        return new UserRecordDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            LoginCount = user.LoginCount
        };
    }
    public static User FromUserRegistrationDto(UserRegistrationDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Username = dto.Username,
            PasswordHash = dto.Password,
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
            PasswordHash = dto.Password,
            LoginRecords = new List<LoginRecord>()
        };
    }
}