using L06_WillianExAppl.Dtos.Estudiantes;
using L06_WillianExAppl.Entities;

namespace L06_WillianExAppl.Services;

public interface IEstudiantesService : IServiceBase<Estudiantes, EstudiantesGetDto, EstudiantesPostDto, EstudiantesPutDto>
{
    
}