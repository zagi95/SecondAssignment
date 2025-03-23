using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Services;

namespace WebAPI.Controllers;

[Route("api/login_records")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly LoginRecordService _recordService;

    public LoginController(LoginRecordService recordService)
    {
        _recordService = recordService;
    }

    [HttpGet]
    public async Task<ActionResult<List<LoginRecordDto>>> GetAll()
    {
        var records = await _recordService.GetAllAsync();
        if (records == null) return NotFound();
        return Ok(records);
    }
}