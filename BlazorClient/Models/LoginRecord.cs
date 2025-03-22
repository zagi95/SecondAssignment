namespace BlazorClient.Models;

public class LoginRecord
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime LoginDate { get; set; }
    public string Browser { get; set; }
}