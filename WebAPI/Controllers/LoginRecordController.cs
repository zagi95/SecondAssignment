using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Services;

namespace WebAPI.Controllers;

[Route("api/login_records")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly LoginService _service;

    public LoginController(LoginService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<LoginRecordDto>>> GetAll()
    {
        var records = await _service.GetAllAsync();
        return Ok(records);
    }
}