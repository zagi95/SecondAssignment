using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Mapper;

public static class UserMapper
{
    public static UserDto ToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,

            // ✅ Map most recent login record if available
            LoginRecordDto = user.LoginRecords
                .OrderByDescending(lr => lr.LoginDate)
                .Select(lr => new LoginRecordDto
                {
                    LoginDate = lr.LoginDate
                })
                .ToList()
        };
    }
    
    public static User ToEntity(UserDto dto)
    {
        return new User
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Username = dto.Username,

            // Mapping LoginRecordDtos to LoginRecords (without Id or UserId for now)
            LoginRecords = dto.LoginRecordDto
                .Select(dtoRecord => new LoginRecord
                {
                    LoginDate = dtoRecord.LoginDate
                    // UserId and User will be handled by EF when saving
                })
                .ToList()
        };
    }
}