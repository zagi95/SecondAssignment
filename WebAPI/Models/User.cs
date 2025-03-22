using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class User
{
    [Key]
    public long Id { get; set; }
    [Required]
    public required string FirstName { get; set; }
    [Required]
    public required string LastName { get; set; }
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string PasswordHash { get; set; }
    public List<LoginRecord> LoginRecords { get; set; } = new();
}