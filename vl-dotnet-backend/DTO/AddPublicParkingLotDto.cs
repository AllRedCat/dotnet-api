using vl_dotnet_backend.Models;

namespace vl_dotnet_backend.DTO;

public class AddPublicParkingLotDto
{
    public string Address { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public List<PublicSchedule>? PublicSchedules { get; set; } = new List<PublicSchedule>();
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int DepartmentId { get; set; }
}