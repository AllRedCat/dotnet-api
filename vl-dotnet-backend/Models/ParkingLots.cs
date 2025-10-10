
using System.ComponentModel.DataAnnotations;

namespace vl_dotnet_backend.Models;

public class ParkingLots
{
    [Key]
    public int Id { get; set; }

    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;
    public int CoveredLots { get; set; }
    public int UncoveredLots { get; set; }
    public decimal PriceHour { get; set; }
    public List<OperationalSchedule>? OperationalSchedule { get; set; } = new List<OperationalSchedule>();

    [MaxLength(255)]
    public string Address { get; set; } = string.Empty;
    [MaxLength(9)]
    public string CEP { get; set; } = string.Empty;
    [MaxLength(255)]
    public string City { get; set; } = string.Empty;
    [MaxLength(2)]
    public string State { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Neighborhood { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Number { get; set; } = string.Empty;
    
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public int UserId { get; set; }
    public Users User { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
