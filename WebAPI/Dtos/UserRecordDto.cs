namespace WebAPI.Dtos;

public class UserRecordDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long LoginCount { get; set; }
}