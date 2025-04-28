using L06_WillianExAppl.Dtos.Materias;
using L06_WillianExAppl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L06_WillianExAppl.Controllers;

[Authorize(Roles = "Admininstrador,Profesor,Estudiante")]
[ApiController]
[Route("api/[controller]")]
public class MateriasController : ControllerBase
{
    private readonly IMateriasService _materiasService;

    public MateriasController(IMateriasService materiasService)
    {
        _materiasService = materiasService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var materias = await _materiasService.GetAll();
        return Ok(materias);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var materia = await _materiasService.GetById(id);
        if (materia == null) 
            return NotFound(new { message = $"Materia con ID {id} no encontrada." });
        return Ok(materia);
    }
    
    [Authorize(Roles = "Admininstrador,Profesor")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody]MateriasPostDto materiasDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var materia = await _materiasService.Add(materiasDto);
        return Ok(materia);
    }
    
    [Authorize(Roles = "Admininstrador,Profesor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MateriasPutDto materiasDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var updated = await _materiasService.Update(id, materiasDto);
        if (!updated) 
            return NotFound(new { message = $"Materia con ID {id} no encontrada." });
        return NoContent();
    }
    
    [Authorize(Roles = "Admininstrador")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _materiasService.Delete(id);
        if (!deleted)
            return NotFound(new { message = $"Materia con ID {id} no encontrada." });
        return NoContent();
    }
    
}