// using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vl_dotnet_backend.Data;
using vl_dotnet_backend.DTO;
using vl_dotnet_backend.Models;

namespace vl_dotnet_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(AppDbContext context) : ControllerBase
{
    // Route get all
    // [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        if (!context.Users.Any())
        {
            return NotFound("No user found.");
        }

        var result = users.Select(user => new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            CPF = user.CPF ?? null,
            Phone = user.Phone ?? null,
            Role = user.Role.ToString(),
            PixKey = user.PixKey ?? null,
            Address = user.Address ?? null,
            CEP = user.CEP ?? null,
            City = user.City ?? null,
            State = user.State ?? null,
            Neighborhood = user.Neighborhood ?? null,
            Number = user.number ?? null,
            CreatedAt = user.CreatedAt,
        }).ToList();

        return Ok(result);
    }
    
    // Route to modify a user
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchUser(int id, [FromBody] UpdateUserDto dto)
    {
        var user = await context.Users.FindAsync(id);
        
        if (user == null) return NotFound("User not found.");
        
        if (dto.Name != null) user.Name = dto.Name;
        if (dto.Email != null) user.Email = dto.Email;
        if (dto.Cpf != null) user.CPF = dto.Cpf;
        if (dto.Phone != null) user.Phone = dto.Phone;
        if (dto.Role.HasValue) user.Role = (Users.RoleType)dto.Role.Value;
        if (dto.PixKey != null) user.PixKey = dto.PixKey;
        if (dto.Address != null) user.Address = dto.Address;
        if (dto.Cep != null) user.CEP = dto.Cep;
        if (dto.City != null) user.City = dto.City;
        if (dto.State != null) user.State = dto.State;
        if (dto.Neighborhood != null) user.Neighborhood = dto.Neighborhood;
        if (dto.Number != null) user.number = dto.Number;
        
        await context.SaveChangesAsync();
        
        return Ok();
    }

    // Route to delete a user
    // [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        // Get the user to be deleted
        var user = await context.Users.FindAsync(id);

        // Check if this user exists in the database
        if (user == null)
        {
            return NotFound();
        }
        
        // Delete the user and await the response from the "context"
        context.Users.Remove(user);
        await context.SaveChangesAsync();

        // Return a status 200
        return Ok();
    }
}