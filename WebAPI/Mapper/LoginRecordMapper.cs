using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Mapper;

public static class LoginRecordMapper
{
    public static LoginRecordDto ToDto(LoginRecord record)
    {
        return new LoginRecordDto
        {
            FirstName = record.User?.FirstName ?? "",
            LastName = record.User?.LastName ?? "",
            LoginDate = record.LoginDate,
            Browser = record.Browser
        };
    }
}