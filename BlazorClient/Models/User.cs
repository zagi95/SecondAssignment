namespace BlazorClient.Models;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public int LoginCount => LoginRecords.Count;
    public required List<LoginRecord> LoginRecords = new List<LoginRecord>();
}