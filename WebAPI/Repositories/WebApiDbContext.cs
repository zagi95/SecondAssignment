using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Repositories;

public class WebApiDbContext :  DbContext
{
    public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<LoginRecord> LoginRecords { get; set; }
}