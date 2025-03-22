namespace WebAPI.Dtos;

public class LoginRecordDto
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime LoginDate { get; set; }
    public string Browser { get; set; }
}