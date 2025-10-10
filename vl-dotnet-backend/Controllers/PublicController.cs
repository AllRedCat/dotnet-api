using Microsoft.AspNetCore.Mvc;
using vl_dotnet_backend.Services;

namespace vl_dotnet_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class PublicController(PublicServices publicServices) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetParkingLots()
    {
        var parkingLots = await publicServices.GetParkingLots();
        
        if (!parkingLots.Any()) return NotFound();
        
        return Ok(parkingLots);
    }
}