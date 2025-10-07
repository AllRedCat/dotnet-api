using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using vl_dotnet_backend.DTO;
using vl_dotnet_backend.Services;

namespace vl_dotnet_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(UserServices userServices) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await userServices.GetAllUsersAsync();
        if (!users.Any()) return NotFound("No users found.");
        return Ok(users);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userServices.GetUserByIdAsync(id);
        if (user == null) return NotFound("User not found.");
        return Ok(user);
    }
    
    [Authorize]
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchUser(int id, [FromBody] UpdateUserDto dto)
    {
        var success = await userServices.UpdateUserAsync(id, dto);
        if (!success) return NotFound("User not found.");
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var success = await userServices.DeleteUserAsync(id);
        if (!success) return NotFound("User not found.");
        return Ok();
    }
}