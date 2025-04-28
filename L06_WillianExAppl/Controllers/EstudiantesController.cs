using L06_WillianExAppl.Dtos.Estudiantes;
using L06_WillianExAppl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L06_WillianExAppl.Controllers;

[Authorize(Roles = "Administrador")]
[ApiController]
[Route("api/[controller]")]
public class EstudiantesController : ControllerBase
{
    private readonly IEstudiantesService _estudiantesService;

    public EstudiantesController(IEstudiantesService estudiantesService)
    {
        _estudiantesService = estudiantesService;
    }
    
    [Authorize(Roles = "Administrador, Profesor")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var estudiantes = await _estudiantesService.GetAll();
        return Ok(estudiantes);
    }
    
    [Authorize(Roles = "Administrador, Profesor")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var estudiante = await _estudiantesService.GetById(id);
        if (estudiante == null) 
            return NotFound(new { message = $"Estudiante con ID {id} no encontrada." });
        return Ok(estudiante);
    }
    
    [Authorize(Roles = "Administrador, Estudiante")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody]EstudiantesPostDto estudiantesDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var estudiante = await _estudiantesService.Add(estudiantesDto);
        return Ok(estudiante);
    }
    
    [Authorize(Roles = "Administrador, Estudiante")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EstudiantesPutDto estudiantesDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var updated = await _estudiantesService.Update(id, estudiantesDto);
        if (!updated) 
            return NotFound(new { message = $"Estudiante con ID {id} no encontrada." });
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _estudiantesService.Delete(id);
        if (!deleted)
            return NotFound(new { message = $"Estudiante con ID {id} no encontrada." });
        return NoContent();
    }
    
}