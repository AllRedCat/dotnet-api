using vl_dotnet_backend.Models;

namespace vl_dotnet_backend.DTO;

public class DepartmentsResponseDto
{
    public int Id { get; set; }
    public string Cnpj { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? PixKey { get; set; } = string.Empty;
    public BankAccount? BankAccount { get; set; }
    public string ContactName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<PublicParkingLotsDto>? PublicParkingLots { get; set; }
}