
using Microsoft.AspNetCore.Mvc;
using vl_dotnet_backend.Data;
using vl_dotnet_backend.DTO;
using vl_dotnet_backend.Models;
using vl_dotnet_backend.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace vl_dotnet_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(
    AppDbContext context,
    PasswordService passwordService,
    IConfiguration configuration,
    ILogger<AuthController> logger)
    : ControllerBase
{
    private readonly ILogger<AuthController> _logger = logger;


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        // Verify if the email already exists
        if (await context.Users.AnyAsync(u => u.Email == registerDto.Email))
        {
            return BadRequest("Email already exists.");
        }

        // Call the function to hash the password
        passwordService.CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        // Create a new object with the user information
        var user = new Users
        {
            Name = registerDto.Name,
            Email = registerDto.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Role = RoleType.Client, // Default role = Client
            CreatedAt = DateTime.UtcNow
        };

        // Save user data on database 'Users' table
        context.Users.Add(user);
        await context.SaveChangesAsync();

        // Return if it's successful
        return Ok(new { message = "User registered successfully" });
    }

    // Route to 'login'
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        // Check the email
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

        // Check the password calling the function from "PasswordService"
        if (user == null || !passwordService.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
        {
            return Unauthorized("Invalid credentials.");
        }

        // Generate a new token
        var token = GenerateJwtToken(user);

        // Set the CORS options for the token
        Response.Cookies.Append("access_token", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddDays(7)
        });

        return Ok(new { message = "Login successful" });
    }

    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized();
        }

        var user = await context.Users.FindAsync(int.Parse(userId));

        if (user == null)
        {
            return NotFound("User not found.");
        }
        
        var userProfile = new UserProfileDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role.ToString()
        };

        return Ok(userProfile);
    }

    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(ChangePassDto changePassDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized();
        }

        var user = await context.Users.FindAsync(int.Parse(userId));
        if (user == null)
        {
            return NotFound("User not found.");
        }

        if (!passwordService.VerifyPasswordHash(changePassDto.OldPassword, user.PasswordHash, user.PasswordSalt))
        {
            return BadRequest("Invalid old password.");
        }

        passwordService.CreatePasswordHash(changePassDto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        await context.SaveChangesAsync();

        return Ok(new { message = "Password changed successfully." });
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("access_token");
        return Ok(new { message = "Logged out successfully" });
    }

    private string GenerateJwtToken(Users user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
