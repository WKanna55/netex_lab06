using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using L06_WillianExAppl.Dtos.Auth;
using L06_WillianExAppl.Dtos.Usuarios;
using L06_WillianExAppl.Entities;
using L06_WillianExAppl.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace L06_WillianExAppl.Services.Base;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher<UsuariosGetDto> _passwordHasher = new PasswordHasher<UsuariosGetDto>();

    public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async Task<JwtSecurityToken> Login(AuthPostDto authDto)
    {
        var usuario = await _unitOfWork.Usuarios.GetByUsername(authDto.Username);
        if (usuario == null) 
            return null;
        
        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, authDto.Password);
        
        if (!VerifyPassword(usuario, authDto.Password))
            return null;
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario.Username),
            new Claim(ClaimTypes.Role, usuario.Rol)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
            (_configuration["Jwt:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);
        
        return token;
    }
    
    public bool VerifyPassword(UsuariosGetDto user, string plainPassword)
    {
        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, plainPassword);
        return result == PasswordVerificationResult.Success;
    }
    
}