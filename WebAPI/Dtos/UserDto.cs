namespace WebAPI.Dtos;

public class UserDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public List<LoginRecordDto> LoginRecordDto { get; set; }
}