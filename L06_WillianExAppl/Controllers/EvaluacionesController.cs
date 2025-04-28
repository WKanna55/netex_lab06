using L06_WillianExAppl.Dtos.Evaluaciones;
using L06_WillianExAppl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L06_WillianExAppl.Controllers;

[Authorize(Roles = "Admininstrador,Profesor,Estudiante")]
[ApiController]
[Route("api/[controller]")]
public class EvaluacionesController : ControllerBase
{
    private readonly IEvaluacionesService _evaluacionesService;

    public EvaluacionesController(IEvaluacionesService evaluacionesService)
    {
        _evaluacionesService = evaluacionesService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var evaluaciones = await _evaluacionesService.GetAll();
        return Ok(evaluaciones);
    }
    
    [Authorize(Roles = "Admininstrador,Profesor")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var evaluacion = await _evaluacionesService.GetById(id);
        if (evaluacion == null) 
            return NotFound(new { message = $"Evaluacion con ID {id} no encontrada." });
        return Ok(evaluacion);
    }
    
    [Authorize(Roles = "Admininstrador,Profesor")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody]EvaluacionesPostDto evaluacionesDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var evaluacion = await _evaluacionesService.Add(evaluacionesDto);
        return Ok(evaluacion);
    }
    
    [Authorize(Roles = "Admininstrador,Profesor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EvaluacionesPutDto evaluacionesDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var updated = await _evaluacionesService.Update(id, evaluacionesDto);
        if (!updated) 
            return NotFound(new { message = $"Evaluacion con ID {id} no encontrada." });
        return NoContent();
    }
    
    [Authorize(Roles = "Admininstrador,Profesor")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _evaluacionesService.Delete(id);
        if (!deleted)
            return NotFound(new { message = $"Evaluacion con ID {id} no encontrada." });
        return NoContent();
    }
    
}