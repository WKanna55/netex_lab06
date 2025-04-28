using L06_WillianExAppl.Dtos.Asistencias;
using L06_WillianExAppl.Entities;
using L06_WillianExAppl.Interfaces;

namespace L06_WillianExAppl.Services.Base;

public class AsistenciasService : 
    ServiceBase<Asistencias, AsistenciasGetDto, AsistenciasPostDto, AsistenciasPutDto>, 
    IAsistenciasService
{
    public AsistenciasService(IUnitOfWork unitOfWork) : base(unitOfWork) {}


    public override Asistencias MapToEntity(AsistenciasPostDto dto)
    {
        return new Asistencias
        {
            IdEstudiante = dto.IdEstudiante,
            IdCurso = dto.IdCurso,
            Fecha = dto.Fecha,
            Estado = dto.Estado
        };
    }

    public override AsistenciasGetDto MapToGetDto(Asistencias entity)
    {
        return new AsistenciasGetDto
        {
            IdAsistencia = entity.IdAsistencia,
            IdEstudiante = entity.IdEstudiante,
            IdCurso = entity.IdCurso,
            Fecha = entity.Fecha,
            Estado = entity.Estado
        };
    }

    public override void MapUpdate(Asistencias entity, AsistenciasPutDto dto)
    {
        entity.IdEstudiante = dto.IdEstudiante;
        entity.IdCurso = dto.IdCurso;
        entity.Fecha = dto.Fecha;
        entity.Estado = dto.Estado;
    }
}