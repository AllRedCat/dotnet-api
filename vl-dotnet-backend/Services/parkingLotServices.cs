using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using vl_dotnet_backend.Data;
using vl_dotnet_backend.DTO;
using vl_dotnet_backend.Models;

namespace vl_dotnet_backend.Services;

public class ParkingLotServices(AppDbContext context)
{
    public async Task<List<ParkingLotResponseDto>> GetAllAsync()
    {
        var lots = await context.ParkingLots.Include(parkingLots => parkingLots.User).ToListAsync();

        return lots.Select(lot => new ParkingLotResponseDto
        {
            Id = lot.Id,
            Name = lot.Name,
            CoveredLots = lot.CoveredLots,
            UncoveredLots = lot.UncoveredLots,
            PriceHour = lot.PriceHour,
            Address = lot.Address,
            Cep = lot.CEP,
            City = lot.City,
            State = lot.State,
            Neighborhood = lot.Neighborhood,
            Number = lot.Number,
            Latitude = lot.Latitude,
            Longitude = lot.Longitude,
            User = new UserDto
            {
                Id = lot.User.Id,
                Name = lot.User.Name,
                Cpf = lot.User.Cpf,
                Phone = lot.User.Phone,
                Role = lot.User.Role,
                PixKey = lot.User.PixKey
            },
            CreatedAt = lot.CreatedAt
        }).ToList();
    }

    public async Task<ParkingLotResponseDto?> GetParkingLotByIdAsync(int id)
    {
        var lot = await context.ParkingLots.Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (lot == null) return null;

        return new ParkingLotResponseDto
        {
            Id = lot.Id,
            Name = lot.Name,
            CoveredLots = lot.CoveredLots,
            UncoveredLots = lot.UncoveredLots,
            PriceHour = lot.PriceHour,
            Address = lot.Address,
            Cep = lot.CEP,
            City = lot.City,
            State = lot.State,
            Neighborhood = lot.Neighborhood,
            Number = lot.Number,
            Latitude = lot.Latitude,
            Longitude = lot.Longitude,
            User = new UserDto
            {
                Id = lot.User.Id,
                Name = lot.User.Name,
                Cpf = lot.User.Cpf,
                Phone = lot.User.Phone,
                Role = lot.User.Role,
                PixKey = lot.User.PixKey
            },
            CreatedAt = lot.CreatedAt
        };
    }

    public async Task<bool> PostParkingLotAsync(string? userId, AddParkingLotDto dto)
    {
        if (await context.ParkingLots.AnyAsync(p => p.Name == dto.Name))
            return false;

        if (userId != null) return false;
        
        var parkingLot = new ParkingLots
        {
            Name = dto.Name,
            CoveredLots = dto.CoveredLots,
            UncoveredLots = dto.UncoveredLots,
            PriceHour = dto.PriceHour,
            // OperationalSchedule = dto.OperationalSchedule,
            Address = dto.Address,
            CEP = dto.Cep,
            City = dto.City,
            State = dto.State,
            Neighborhood = dto.Neighborhood,
            Number = dto.Number,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            UserId = int.Parse(userId)
        };
        
        context.ParkingLots.Add(parkingLot);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> PatchParkingLotAsync(int id, UpdateParkingLotDto dto)
    {
        var lot = await context.ParkingLots.FindAsync(id);
        
        if (lot == null) return false;

        if (dto.Name != null) lot.Name = dto.Name;
        if (dto.CoveredLots != null) lot.CoveredLots = dto.CoveredLots.Value;
        if (dto.UncoveredLots != null) lot.UncoveredLots = dto.UncoveredLots.Value;
        if (dto.PriceHour != null) lot.PriceHour = dto.PriceHour.Value;
        if (dto.Address != null) lot.Address = dto.Address;
        if (dto.Cep != null) lot.CEP = dto.Cep;
        if (dto.City != null) lot.City = dto.City;
        if (dto.State != null) lot.State = dto.State;
        if (dto.Neighborhood != null) lot.Neighborhood = dto.Neighborhood;
        if (dto.Number != null) lot.Number = dto.Number;
        if (dto.Latitude != null) lot.Latitude = dto.Latitude.Value;
        if (dto.Longitude != null) lot.Longitude = dto.Longitude.Value;
        lot.UpdatedAt = DateTime.Now;
        
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteParkingLotAsync(int id)
    {
        var lot = await context.ParkingLots.FindAsync(id);
        
        if (lot == null) return false;
        
        context.ParkingLots.Remove(lot);
        await context.SaveChangesAsync();
        
        return true;
    }
}