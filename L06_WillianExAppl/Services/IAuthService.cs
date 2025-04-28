using System.IdentityModel.Tokens.Jwt;
using L06_WillianExAppl.Dtos.Auth;

namespace L06_WillianExAppl.Services;

public interface IAuthService
{
    Task<JwtSecurityToken> Login(AuthPostDto authDto);
}