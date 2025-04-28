using L06_WillianExAppl.Dtos.Auth;
using L06_WillianExAppl.Dtos.Usuarios;
using L06_WillianExAppl.Entities;

namespace L06_WillianExAppl.Interfaces;

public interface IUsuariosRepository: IRepository<Usuarios>
{
    Task<UsuariosGetDto> GetByUsername(string dtoUsername);
}