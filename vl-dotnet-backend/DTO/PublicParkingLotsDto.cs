using vl_dotnet_backend.Models;

namespace vl_dotnet_backend.DTO;

public class PublicParkingLotsDto
{
    public int Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public bool Status { get; set; }
    public List<PublicSchedule>? PublicSchedules { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}