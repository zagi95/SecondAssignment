using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

public class LoginRecord
{
    [Key]
    public long Id { get; set; }
    [Required]
    public DateTime LoginDate { get; set; }
    [ForeignKey("User")]
    public long UserId { get; set; }
    public User? User { get; set; }
}