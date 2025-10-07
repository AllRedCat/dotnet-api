namespace vl_dotnet_backend.DTO;

public class UpdateUserDto
{
    public string? Name { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string? Cpf { get; set; }
    public string? Phone { get; set; }
    public RoleType? Role { get; set; }
    public string? PixKey { get; set; }
    
    public string? Address { get; set; }
    public string? Cep { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Neighborhood { get; set; }
    public string? Number { get; set; }
}