using L06_WillianExAppl.Dtos.Cursos;
using L06_WillianExAppl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L06_WillianExAppl.Controllers;

[Authorize(Roles = "Administrador,Profesor")]
[ApiController]
[Route("api/[controller]")]
public class CursosController : ControllerBase
{
    private readonly ICursosService _cursosService;

    public CursosController(ICursosService cursosService)
    {
        _cursosService = cursosService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cursos = await _cursosService.GetAll();
        return Ok(cursos);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var curso = await _cursosService.GetById(id);
        if (curso == null) 
            return NotFound(new { message = $"Curso con ID {id} no encontrada." });
        return Ok(curso);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody]CursosPostDto cursosDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var curso = await _cursosService.Add(cursosDto);
        return Ok(curso);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CursosPutDto cursosDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var updated = await _cursosService.Update(id, cursosDto);
        if (!updated) 
            return NotFound(new { message = $"Curso con ID {id} no encontrada." });
        return NoContent();
    }
    
    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _cursosService.Delete(id);
        if (!deleted)
            return NotFound(new { message = $"Curso con ID {id} no encontrada." });
        return NoContent();
    }
}