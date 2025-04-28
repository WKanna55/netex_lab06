using L06_WillianExAppl.Dtos.Usuarios;
using L06_WillianExAppl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L06_WillianExAppl.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuariosService _usuariosService;

    public UsuariosController(IUsuariosService usuariosService)
    {
        _usuariosService = usuariosService;
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuariosService.GetAll();

        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var usuario = await _usuariosService.GetById(id);
        if (usuario == null) 
            return NotFound(new { message = $"Usuario con ID {id} no encontrado." });
        return Ok(usuario);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UsuariosPostDto usuarioDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest();

        var usuario = await _usuariosService.Add(usuarioDto);
        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UsuariosPutDto usuarioDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest();
        
        var updated = await _usuariosService.Update(id, usuarioDto);
        if (!updated)
            return NotFound(new { message = $"Usuario con ID {id} no encontrado." });
        
        return NoContent();
    }

    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _usuariosService.Delete(id);
        if (!deleted)
            return NotFound(new { message = $"Usuario con ID {id} no encontrado." });
        return NoContent();
    }
    
}