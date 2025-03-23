using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Services;

namespace WebAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly AuthenticationService _authenticationService;

    public AuthenticationController(AuthenticationService authenticationService) => _authenticationService = authenticationService;

    [HttpPost("register")]
    public async Task<ActionResult<UserRegistrationDto>> Register(UserRegistrationDto dto)
    {
        var user = await _authenticationService.RegisterAsync(dto);
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginRecordDto>> Login(UserLoginDto dto)
    {
        Console.WriteLine("LoginUser");
        Console.WriteLine(Request.Headers["User-Agent"]);
        dto.Browser = UserAgentParser.GetBrowserInfo(Request.Headers["User-Agent"].ToString());
        var record = await _authenticationService.LoginAsync(dto);
        if (record == null) return Unauthorized();
        return Ok(record);
    }
}