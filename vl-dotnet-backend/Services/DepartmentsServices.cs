using Microsoft.EntityFrameworkCore;
using vl_dotnet_backend.Data;
using vl_dotnet_backend.DTO;
using vl_dotnet_backend.Models;

namespace vl_dotnet_backend.Services;

public class DepartmentsServices(AppDbContext context)
{
    // GET all
    public async Task<List<DepartmentsResponseDto>> GetAllAsync()
    {
        var departments = await context.TransportDepartments
            .Include(d => d.PublicParkingLots)
            .ToListAsync();
        
        // Map the items in "departments" and return as JSON
        return departments.Select(d => new DepartmentsResponseDto
        {
            Id = d.Id,
            Cnpj = d.Cnpj,
            Name = d.Name,
            PixKey = d.PixKey,
            BankAccount = new BankAccount
            {
                Account = d.BankAccount!.Account,
                Agency = d.BankAccount.Agency,
            },
            ContactName = d.ContactName,
            Phone = d.Phone,
            Email = d.Email,
            City = d.City,
            State = d.State,
            Price = d.Price,
            PublicParkingLots = d.PublicParkingLots?
                .Select(p => new PublicParkingLotsDto
                {
                    Id = p.Id,
                    Address = p.Address,
                    Number = p.Number,
                    Cep = p.Cep,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude,
                    Status = p.Status,
                    PublicSchedules = p.PublicSchedules,
                    CreatedAt = p.CreatedAt,
                }).ToList(),
            CreatedAt = d.CreatedAt,
        }).ToList();
    }
    
    // GET by ID
    public async Task<DepartmentsResponseDto?> GetByIdAsync(int id)
    {
        var department = await context.TransportDepartments
            .Include(d => d.PublicParkingLots)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (department == null) return null;

        return new DepartmentsResponseDto
        {
            Id = department.Id,
            Cnpj = department.Cnpj,
            Name = department.Name,
            PixKey = department.PixKey,
            BankAccount = new BankAccount
            {
                Account = department.BankAccount!.Account,
                Agency = department.BankAccount.Agency,
            },
            ContactName = department.ContactName,
            Phone = department.Phone,
            Email = department.Email,
            City = department.City,
            State = department.State,
            Price = department.Price,
            PublicParkingLots = department.PublicParkingLots?
                .Select(p => new PublicParkingLotsDto
                {
                    Id = p.Id,
                    Address = p.Address,
                    Number = p.Number,
                    Cep = p.Cep,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude,
                    Status = p.Status,
                    PublicSchedules = p.PublicSchedules,
                    CreatedAt = p.CreatedAt,
                }).ToList(),
            CreatedAt = department.CreatedAt,
        };
    }
    
    // POST
    public async Task<bool> Post(AddTransportDepartmentDto dto)
    {
        if (await context.TransportDepartments
                .AnyAsync(d => d.Name == dto.Name) &&
            await context.TransportDepartments
                .AnyAsync(d => d.Cnpj == dto.Cnpj))
            return false;

        var department = new TransportDepartments
        {
            Cnpj = dto.Cnpj,
            Name = dto.Name,
            PixKey = dto.PixKey,
            BankAccount = dto.BankAccount,
            ContactName = dto.ContactName,
            Phone = dto.Phone,
            Email = dto.Email,
            City = dto.City,
            State = dto.State,
            Price = dto.Price
        };
        
        context.TransportDepartments.Add(department);
        await context.SaveChangesAsync();
        
        return true;
    }
    
    // PATCH
    public async Task<bool> Patch(int id, UpdateDepartmentDto dto)
    {
        var department = await context.TransportDepartments
            .FindAsync(id);

        if (department == null) return false;
        
        if (dto.Cnpj != department.Cnpj) department.Cnpj = dto.Cnpj!;
        if (dto.Name != department.Name) department.Name = dto.Name!;
        if (dto.PixKey != department.PixKey) department.PixKey = dto.PixKey;
        if (dto.BankAccount != department.BankAccount) department.BankAccount = dto.BankAccount;
        if (dto.ContactName != department.ContactName) department.ContactName = dto.ContactName!;
        if (dto.Phone != department.Phone) department.Phone = dto.Phone!;
        if (dto.Email != department.Email) department.Email = dto.Email!;
        if (dto.City != null && dto.City != department.City) department.City = dto.City;
        if (dto.State != null&& dto.State != department.State) department.State = dto.State;
        if (dto.Price != department.Price) department.Price = (decimal)dto.Price!;
        
        await context.SaveChangesAsync();
        
        return true;
    }
    
    // DELETE
    public async Task<bool> Delete(int id)
    {
        var department = await context.TransportDepartments
            .FindAsync(id);

        if (department == null) return false;

        context.TransportDepartments.Remove(department);
        await context.SaveChangesAsync();

        return true;
    }
}