using Microsoft.EntityFrameworkCore;
using vl_dotnet_backend.Data;
using vl_dotnet_backend.DTO;

namespace vl_dotnet_backend.Services;

public class UserServices(AppDbContext context)
{
    public async Task<List<UserDto>> GetAllUsersAsync()
     {
        var users = await context.Users.ToListAsync();

        return users.Select(user => new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Cpf = user.Cpf,
            Phone = user.Phone,
            Role = user.Role,
            PixKey = user.PixKey,
            Address = user.Address,
            CEP = user.Cep,
            City = user.City,
            State = user.State,
            Neighborhood = user.Neighborhood,
            Number = user.Number,
            CreatedAt = user.CreatedAt
        }).ToList();
    }

    public async Task<UserDto?> GetUserByIdAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Cpf = user.Cpf,
            Phone = user.Phone,
            Role = user.Role,
            PixKey = user.PixKey,
            Address = user.Address,
            CEP = user.Cep,
            City = user.City,
            State = user.State,
            Neighborhood = user.Neighborhood,
            Number = user.Number,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<bool> UpdateUserAsync(int id, UpdateUserDto dto)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return false;

        if (dto.Name != null) user.Name = dto.Name;
        if (dto.Email != null) user.Email = dto.Email;
        if (dto.Cpf != null) user.Cpf = dto.Cpf;
        if (dto.Phone != null) user.Phone = dto.Phone;
        if (dto.Role.HasValue) user.Role = dto.Role.Value;
        if (dto.PixKey != null) user.PixKey = dto.PixKey;
        if (dto.Address != null) user.Address = dto.Address;
        if (dto.Cep != null) user.Cep = dto.Cep;
        if (dto.City != null) user.City = dto.City;
        if (dto.State != null) user.State = dto.State;
        if (dto.Neighborhood != null) user.Neighborhood = dto.Neighborhood;
        if (dto.Number != null) user.Number = dto.Number;

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return false;

        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return true;
    }
}