using Microsoft.AspNetCore.Mvc;
using vl_dotnet_backend.DTO;
using vl_dotnet_backend.Services;

namespace vl_dotnet_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class PublicParkingLotsController(PublicParkingLotsServices publicParkingLotsServices) : ControllerBase
{
    // GET
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await publicParkingLotsServices.GetAll();
        return Ok(result);
    }
    
    // GET by Id
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await publicParkingLotsServices.GetById(id);
        if (result == null) return NotFound("Public parking lot not found");
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Post(AddPublicParkingLotDto dto)
    {
        var result = await publicParkingLotsServices.Post(dto);
        if (!result) return BadRequest();
        return Ok();
    }
    
    // PATCH
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, UpdatePublicParkingLotDto dto)
    {
        var result = await publicParkingLotsServices.Patch(id, dto);
        if (!result) return BadRequest();
        return Ok();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await publicParkingLotsServices.Delete(id);
        if (!result) return BadRequest();
        return Ok();
    }
}