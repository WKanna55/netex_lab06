using L06_WillianExAppl.Dtos.Cursos;
using L06_WillianExAppl.Entities;

namespace L06_WillianExAppl.Services;

public interface ICursosService : IServiceBase<Cursos, CursosGetDto, CursosPostDto, CursosPutDto>
{
    
}