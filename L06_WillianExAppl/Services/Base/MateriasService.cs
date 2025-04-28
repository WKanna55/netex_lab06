
using L06_WillianExAppl.Dtos.Materias;
using L06_WillianExAppl.Entities;
using L06_WillianExAppl.Interfaces;

namespace L06_WillianExAppl.Services.Base;

public class MateriasService : 
    ServiceBase<Materias, MateriasGetDto, MateriasPostDto, MateriasPutDto>, IMateriasService
{
    public MateriasService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    public override Materias MapToEntity(MateriasPostDto dto)
    {
        return new Materias
        {
            IdCurso = dto.IdCurso,
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion
        };
    }

    public override MateriasGetDto MapToGetDto(Materias entity)
    {
        return new MateriasGetDto
        {
            IdMateria = entity.IdMateria,
            IdCurso = entity.IdCurso,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion
        };
    }

    public override void MapUpdate(Materias entity, MateriasPutDto dto)
    {
        entity.IdCurso = dto.IdCurso;
        entity.Nombre = dto.Nombre;
        entity.Descripcion = dto.Descripcion;
    }
}