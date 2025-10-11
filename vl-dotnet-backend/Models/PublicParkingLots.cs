using System.ComponentModel.DataAnnotations;

namespace vl_dotnet_backend.Models;

public class PublicParkingLots
{
    [Key]
    public int Id { get; set; }
    [MaxLength(255)]
    public string Address { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Number { get; set; } = string.Empty;
    [MaxLength(9)]
    public string Cep { get; set; } = string.Empty;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public bool Status { get; set; }
    public List<PublicSchedule>? PublicSchedules { get; set; } = new List<PublicSchedule>();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    // Relations
    public int DepartmentId { get; set; }
    public TransportDepartments Department { get; set; } = new  TransportDepartments();
}