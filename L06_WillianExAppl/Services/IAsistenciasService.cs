using L06_WillianExAppl.Dtos.Asistencias;
using L06_WillianExAppl.Entities;

namespace L06_WillianExAppl.Services;

public interface IAsistenciasService : 
    IServiceBase<Asistencias, AsistenciasGetDto, AsistenciasPostDto, AsistenciasPutDto>
{
    
}