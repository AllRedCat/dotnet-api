using vl_dotnet_backend.Models;

namespace vl_dotnet_backend.DTO;

public class UpdateParkingLotDto
{
    public string? Name { get; set; }
    public int? CoveredLots { get; set; }
    public int? UncoveredLots { get; set; }
    public decimal? PriceHour { get; set; }
    public List<OperationalSchedule>? OperationalSchedule { get; set; }
    public string? Address { get; set; }
    public string? Cep { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Neighborhood { get; set; }
    public string? Number { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}