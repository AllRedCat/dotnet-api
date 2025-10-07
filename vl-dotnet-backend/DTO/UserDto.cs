namespace vl_dotnet_backend.DTO;

public class UserDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? CPF { get; set; }
    public string? Phone { get; set; }
    public string Role { get; set; } = string.Empty;
    public string? PixKey { get; set; }
    
    public string? Address { get; set; }
    public string? CEP { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Neighborhood { get; set; }
    public string? Number { get; set; }
    
    
    public DateTime CreatedAt { get; set; }
}