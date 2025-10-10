namespace vl_dotnet_backend.DTO;

public class PublicPlResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CoveredLots { get; set; }
    public int UncoveredLots { get; set; }
    public decimal PriceHour { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime CreatedAt { get; set; }
}