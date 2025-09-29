namespace vl_dotnet_backend.Models;

public class ParkingLots
{
    public int Id { get; set; }

    // Parking lot data
    public string Name { get; set; }
    public int CoveredLots { get; set; }
    public int UncoveredLots { get; set; }
    public decimal PriceHour { get; set; }
    public OperationalSchedule[] OperationalSchedule { get; set; }

    // Adress data
    public string Address { get; set; }
    public string CEP { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Neighborhood { get; set; }
    public string Number { get; set; }
    
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    // Relationships
    public int OwnerId { get; set; }
    public Users User { get; set; } = null!;
    
    // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}