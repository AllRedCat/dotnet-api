namespace vl_dotnet_backend.DTO;

public class UpdatePublicParkingLotDto
{
    public string? Address { get; set; }
    public string? Number { get; set; }
    public string? Cep { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public bool? Status { get; set; } 
}