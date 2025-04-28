using L06_WillianExAppl.Dtos.Evaluaciones;
using L06_WillianExAppl.Entities;

namespace L06_WillianExAppl.Services;

public interface IEvaluacionesService : 
    IServiceBase<Evaluaciones, EvaluacionesGetDto, EvaluacionesPostDto, EvaluacionesPutDto>
{
    
}