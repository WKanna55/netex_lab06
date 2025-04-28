using L06_WillianExAppl.Dtos.Profesores;
using L06_WillianExAppl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L06_WillianExAppl.Controllers;

[Authorize(Roles = "Administrador,Profesor")]
[ApiController]
[Route("api/[controller]")]
public class ProfesoresController : ControllerBase
{
    private readonly IProfesoresService _profesoresService;

    public ProfesoresController(IProfesoresService profesoresService)
    {
        _profesoresService = profesoresService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var profesores = await _profesoresService.GetAll();
        return Ok(profesores);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var profesor = await _profesoresService.GetById(id);
        if (profesor == null) 
            return NotFound(new { message = $"Profesor con ID {id} no encontrada." });
        return Ok(profesor);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody]ProfesoresPostDto profesoresDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var profesor = await _profesoresService.Add(profesoresDto);
        return Ok(profesor);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProfesoresPutDto profesoresDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var updated = await _profesoresService.Update(id, profesoresDto);
        if (!updated) 
            return NotFound(new { message = $"Profesor con ID {id} no encontrada." });
        return NoContent();
    }
    
    [Authorize(Roles = "Admininstrador")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _profesoresService.Delete(id);
        if (!deleted)
            return NotFound(new { message = $"Profesor con ID {id} no encontrada." });
        return NoContent();
    }
    
}