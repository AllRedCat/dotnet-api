using Microsoft.EntityFrameworkCore;
using vl_dotnet_backend.Data;
using vl_dotnet_backend.DTO;
using vl_dotnet_backend.Models;

namespace vl_dotnet_backend.Services;

public class PublicParkingLotsServices(AppDbContext context)
{
    // GET all
    public async Task<List<PublicParkingLots>> GetAll()
    {
        return await context.PublicParkingLots.ToListAsync();
    }

    // GET by Id
    public async Task<PublicParkingLots?> GetById(int id)
    {
        // var lot = await context.PublicParkingLots.FindAsync(id);
        // if (lot == null) return null;   
        return await context.PublicParkingLots.FindAsync(id);
    }

    // POST
    public async Task<bool> Post(AddPublicParkingLotDto dto)
    {
        var dep = await context.TransportDepartments.FindAsync(dto.DepartmentId);

        if (dep == null) return false;
        
        var lot = new PublicParkingLots
        {
            Address = dto.Address,
            Number = dto.Number,
            Cep = dto.Cep,
            PublicSchedules = dto.PublicSchedules,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            Status = false,
            DepartmentId = dto.DepartmentId,
            Department = dep
        };
        
        context.PublicParkingLots.Add(lot);
        await context.SaveChangesAsync();

        return true;
    }
    
    // PATCH
    public async Task<bool> Patch(int id, UpdatePublicParkingLotDto dto)
    {
        var lot = await context.PublicParkingLots
            .FindAsync(id);

        if (lot == null) return false;
        
        if (dto.Address != lot.Address) lot.Address = dto.Address!;
        if (dto.Number != lot.Number) lot.Number = dto.Number!;
        if (dto.Cep != lot.Cep) lot.Cep = dto.Cep!;
        if (dto.Latitude != lot.Latitude) lot.Latitude = (decimal)dto.Latitude!;
        if (dto.Longitude != lot.Longitude) lot.Longitude = (decimal)dto.Longitude!;
        if (dto.Status != lot.Status) lot.Status = (bool)dto.Status!;
        
        await context.SaveChangesAsync();
        
        return true;
    }
    
    // DELETE
    public async Task<bool> Delete(int id)
    {
        var lot = await context.PublicParkingLots.FindAsync(id);
        
        if (lot == null) return false;
        
        context.PublicParkingLots.Remove(lot);
        await context.SaveChangesAsync();
        
        return true;
    }
}