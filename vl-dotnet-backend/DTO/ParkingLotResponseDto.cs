namespace vl_dotnet_backend.DTO;

public class ParkingLotResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CoveredLots { get; set; }
    public int UncoveredLots { get; set; }
    public decimal PriceHour { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public UserDto? User { get; set; }
    public DateTime CreatedAt { get; set; }
}
