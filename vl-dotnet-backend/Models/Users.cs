
using System.ComponentModel.DataAnnotations;

namespace vl_dotnet_backend.Models;

public class Users
{
    public enum RoleType
    {
        Admin,
        Client,
        User
    }
    
    public int Id { get; set; }
    
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(14)]
    public string? CPF { get; set; }
    [MaxLength(32)]
    public string? Phone { get; set; }
    public RoleType Role { get; set; }
    [MaxLength(255)]
    public string? PixKey { get; set; }
    
    [MaxLength(255)]
    public string? Address { get; set; }
    [MaxLength(9)]
    public string? CEP { get; set; }
    [MaxLength(255)]
    public string? City { get; set; }
    [MaxLength(2)]
    public string? State { get; set; }
    [MaxLength(255)]
    public string? Neighborhood { get; set; }
    [MaxLength(100)]
    public string? number { get; set; }
    
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    
    public ICollection<ParkingLots> ParkingLots { get; set; } = new List<ParkingLots>();
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
