using L06_WillianExAppl.Data;
using L06_WillianExAppl.Dtos.Auth;
using L06_WillianExAppl.Dtos.Usuarios;
using L06_WillianExAppl.Entities;
using L06_WillianExAppl.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace L06_WillianExAppl.Repositories;

public class UsuariosRepository : Repository<Usuarios>, IUsuariosRepository
{
    private readonly ApplicationDbContext _context;

    public UsuariosRepository(ApplicationDbContext _context) : base(_context)
    {
        this._context = _context;
    }

    public async Task<UsuariosGetDto> GetByUsername(string dtoUsername)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u 
            => u.Username == dtoUsername);
        if (usuario == null) 
            return null;
        var usuarioDto = usuario.Adapt<UsuariosGetDto>();
        return usuarioDto;
    }
    
}