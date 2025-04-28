using L06_WillianExAppl.Dtos.Cursos;
using L06_WillianExAppl.Entities;
using L06_WillianExAppl.Interfaces;

namespace L06_WillianExAppl.Services.Base;

public class CursosService : 
    ServiceBase<Cursos, CursosGetDto, CursosPostDto, CursosPutDto>, ICursosService
{
    public CursosService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    public override Cursos MapToEntity(CursosPostDto dto)
    {
        return new Cursos
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            Creditos = dto.Creditos
        };
    }

    public override CursosGetDto MapToGetDto(Cursos entity)
    {
        return new CursosGetDto
        {
            IdCurso = entity.IdCurso,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion,
            Creditos = entity.Creditos
        };
    }

    public override void MapUpdate(Cursos entity, CursosPutDto dto)
    {
        entity.Nombre = dto.Nombre;
        entity.Descripcion = dto.Descripcion;
        entity.Creditos = dto.Creditos;
    }
}