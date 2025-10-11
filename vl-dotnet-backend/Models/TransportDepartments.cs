using System.ComponentModel.DataAnnotations;

namespace vl_dotnet_backend.Models;

public class TransportDepartments
{
    [Key]
    public int Id { get; set; }
    [MaxLength(18)]
    public string Cnpj { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(255)]
    public string? PixKey { get; set; } = string.Empty;
    public BankAccount? BankAccount { get; set; }
    [MaxLength(255)]
    public string ContactName { get; set; } = string.Empty;
    [MaxLength(32)]
    public string Phone { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    [MaxLength(255)]
    public string City { get; set; } = string.Empty;
    [MaxLength(2)]
    public string State { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    // Relations
    public ICollection<PublicParkingLots> PublicParkingLots { get; set; } = new List<PublicParkingLots>();
}