using L06_WillianExAppl.Dtos.Usuarios;
using L06_WillianExAppl.Entities;
using L06_WillianExAppl.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace L06_WillianExAppl.Services.Base;

public class UsuariosService : 
    ServiceBase<Usuarios, UsuariosGetDto, UsuariosPostDto, UsuariosPutDto>, IUsuariosService
{

    // hashear contraseñas
    private readonly PasswordHasher<UsuariosPostDto> _passwordHasher = new PasswordHasher<UsuariosPostDto>();
    
    public UsuariosService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    public override Usuarios MapToEntity(UsuariosPostDto dto) => dto.Adapt<Usuarios>();

    public override UsuariosGetDto MapToGetDto(Usuarios entity) => entity.Adapt<UsuariosGetDto>();

    public override void MapUpdate(Usuarios entity, UsuariosPutDto dto) => dto.Adapt(entity);

    /*
     * Metodo cambiado con polimorfismo para hashear contraseñas
     */
    public override async Task<UsuariosGetDto> Add(UsuariosPostDto dto)
    {
        var hashedPassword = _passwordHasher.HashPassword(dto, dto.Password);
        dto.Password = hashedPassword;
        return await base.Add(dto);
    }
}