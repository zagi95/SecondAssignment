namespace BlazorClient.Models;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int LoginCount {  get; set; }
}