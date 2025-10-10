using Microsoft.EntityFrameworkCore;
using vl_dotnet_backend.Data;
using vl_dotnet_backend.DTO;

namespace vl_dotnet_backend.Services;

public class PublicServices (AppDbContext context)
{
    public async Task<List<PublicPlResponseDto>> GetParkingLots()
    {
        var lots = await context.ParkingLots.ToListAsync();

        return lots.Select(lot => new PublicPlResponseDto
        {
            Id = lot.Id,
            Name = lot.Name,
            CoveredLots = lot.CoveredLots,
            UncoveredLots = lot.UncoveredLots,
            PriceHour = lot.PriceHour,
            Address = lot.Address,
            Number = lot.Number,
            Latitude = lot.Latitude,
            Longitude = lot.Longitude,
            CreatedAt = lot.CreatedAt,
        }).ToList();
    }
}