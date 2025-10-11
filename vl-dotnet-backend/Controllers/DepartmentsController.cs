using Microsoft.AspNetCore.Mvc;
using vl_dotnet_backend.DTO;
using vl_dotnet_backend.Services;

namespace vl_dotnet_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController(DepartmentsServices departmentsServices) : ControllerBase
{
    // GET
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await departmentsServices.GetAllAsync();
        if (!result.Any()) return NotFound("No transport departments found");
        return Ok(result);
    }
    
    // GET by Id
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await departmentsServices.GetByIdAsync(id);
        if (result == null) return NotFound("No transport departments found");
        return Ok(result);
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Post(AddTransportDepartmentDto dto)
    {
        var result = await departmentsServices.Post(dto);
        if (!result) return BadRequest();
        return Ok();
    }
    
    // PATCH
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, UpdateDepartmentDto dto)
    {
        var result = await departmentsServices.Patch(id, dto);
        if (!result) return NotFound();
        return Ok();
    }
    
    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await departmentsServices.Delete(id);
        if (!result) return BadRequest();
        return Ok();
    }
}