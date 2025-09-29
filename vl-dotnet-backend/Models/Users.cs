using System.ComponentModel.DataAnnotations;

namespace vl_dotnet_backend.Models;

public class Users
{
    public int Id { get; set; }
    
    // Personal data
    [MaxLength(255)]
    public string Name { get; set; }
    [MaxLength(14)]
    public string CPF { get; set; }
    public string Phone { get; set; }
    
    // Adress data
    public string Address { get; set; }
    public string CEP { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Neighborhood { get; set; }
    public string number { get; set; }
    
    // Login data
    public string Email { get; set; }
    public string Password { get; set; }
    
    // Relationships
    public ICollection<ParkingLots> ParkingLots { get; set; } = new List<ParkingLots>();
    
    // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}