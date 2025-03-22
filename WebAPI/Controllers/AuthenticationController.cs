using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Services;

namespace WebAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthenticationController(AuthService authService) => _authService = authService;

    [HttpPost("register")]
    public async Task<ActionResult<UserRegistrationDto>> Register(UserRegistrationDto dto)
    {
        var user = await _authService.RegisterAsync(dto);
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginRecordDto>> Login(UserLoginDto dto)
    {
        var record = await _authService.LoginAsync(dto);
        if (record == null) return Unauthorized();
        return Ok(record);
    }
}