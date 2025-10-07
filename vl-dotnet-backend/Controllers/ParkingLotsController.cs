using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vl_dotnet_backend.Data;
using vl_dotnet_backend.DTO;
using vl_dotnet_backend.Models;
using vl_dotnet_backend.Services;

namespace vl_dotnet_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkingLotsController (ParkingLotServices parkingLotServices) : ControllerBase
{
    // Route to create a new parking lot
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post(AddParkingLotDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var parkingLot = await parkingLotServices.PostParkingLotAsync(userId, dto);

        return Ok(parkingLot);
    }

    // [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetParkingLots()
    {
        var parkingLots = await parkingLotServices.GetAllAsync();
        if (!parkingLots.Any()) return NotFound("No Parking Lots Found");
        return Ok(parkingLots);
    }

    // [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var parkingLot = await parkingLotServices.GetParkingLotByIdAsync(id);

        if (parkingLot == null) return NotFound("Parking lot not found.");

        return Ok(parkingLot);
    }

    [Authorize]
    [HttpPatch("{id}")]
    public async Task<IActionResult> Post(int id, [FromBody] UpdateParkingLotDto dto)
    {
        var success = await parkingLotServices.PatchParkingLotAsync(id, dto);
        
        if (!success) return NotFound("Parking Lot Not Found.");
        
        return Ok();
    }
    
    // Route to delete a parking lot
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await parkingLotServices.DeleteParkingLotAsync(id);
        
        if (!success) return NotFound("Parking Lot Not Found.");

        return Ok();
    }
}