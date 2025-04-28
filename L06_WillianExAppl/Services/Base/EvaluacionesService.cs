using L06_WillianExAppl.Dtos.Evaluaciones;
using L06_WillianExAppl.Entities;
using L06_WillianExAppl.Interfaces;

namespace L06_WillianExAppl.Services.Base;

public class EvaluacionesService : 
    ServiceBase<Evaluaciones, EvaluacionesGetDto, EvaluacionesPostDto, EvaluacionesPutDto>, IEvaluacionesService
{
    public EvaluacionesService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public override Evaluaciones MapToEntity(EvaluacionesPostDto dto)
    {
        return new Evaluaciones
        {
            IdEstudiante = dto.IdEstudiante,
            IdCurso = dto.IdCurso,
            Calificacion = dto.Calificacion,
            Fecha = dto.Fecha
        };
    }

    public override EvaluacionesGetDto MapToGetDto(Evaluaciones entity)
    {
        return new EvaluacionesGetDto
        {
            IdEvaluacion = entity.IdEvaluacion,
            IdEstudiante = entity.IdEstudiante,
            IdCurso = entity.IdCurso,
            Calificacion = entity.Calificacion,
            Fecha = entity.Fecha
        };
    }

    public override void MapUpdate(Evaluaciones entity, EvaluacionesPutDto dto)
    {
        entity.IdEstudiante = dto.IdEstudiante;
        entity.IdCurso = dto.IdCurso;
        entity.Calificacion = dto.Calificacion;
        entity.Fecha = dto.Fecha;
    }
}