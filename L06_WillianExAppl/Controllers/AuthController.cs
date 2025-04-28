using System.IdentityModel.Tokens.Jwt;
using L06_WillianExAppl.Dtos.Auth;
using L06_WillianExAppl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L06_WillianExAppl.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthPostDto authDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var getToken = await _authService.Login(authDto);
        if (getToken == null) 
            return NotFound();
        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(getToken)
        });
    }
    
}