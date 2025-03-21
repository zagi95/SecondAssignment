using Microsoft.EntityFrameworkCore;
using WebAPI.Repositories;
using WebAPI.Services;

namespace WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        builder.Services.AddScoped<UserService>()
            .AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddDbContext<WebApiDbContext>(options =>
            options.UseInMemoryDatabase("MyPrototypeDb"));


        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        //app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}