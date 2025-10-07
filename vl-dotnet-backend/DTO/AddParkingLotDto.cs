using System.ComponentModel.DataAnnotations;
using vl_dotnet_backend.Models;

namespace vl_dotnet_backend.DTO;

public class AddParkingLotDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public int CoveredLots { get; set; }
    [Required]
    public int UncoveredLots { get; set; }
    [Required]
    public decimal PriceHour { get; set; }
    [Required]
    public List<OperationalSchedule>? OperationalSchedules { get; set; } = new List<OperationalSchedule>();
    [Required]
    public string Cep { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    public string City { get; set; }  = string.Empty;
    [Required]
    public string State { get; set; } = string.Empty;
    [Required]
    public string Neighborhood { get; set; } = string.Empty;
    [Required]
    public string Number { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int UserId { get; set; }
}