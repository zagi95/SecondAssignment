using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Services;

namespace WebAPI.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserRecordDto>>> GetUsers()
    {
        var users = await _userService.GetUsersAsync();
        if (users == null) return NotFound();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserRecordDto>> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserRecordDto>> AddUser(UserRegistrationDto userRegistrationDto)
    {
        var createdUserRecord = await _userService.AddUserAsync(userRegistrationDto);
        return CreatedAtAction(
            nameof(GetUserById),
            new { id = createdUserRecord.Id },
            createdUserRecord
            );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserRecordDto>> UpdateUser(long id, UserRegistrationDto userRegistrationDto)
    {
        var updatedUser = await _userService.UpdateUserAsync(id, userRegistrationDto);
        if (updatedUser == null) return NotFound();
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUserAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}