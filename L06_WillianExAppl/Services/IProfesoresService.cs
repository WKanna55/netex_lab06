using L06_WillianExAppl.Dtos.Profesores;
using L06_WillianExAppl.Entities;

namespace L06_WillianExAppl.Services;

public interface IProfesoresService : 
    IServiceBase<Profesores, ProfesoresGetDto, ProfesoresPostDto, ProfesoresPutDto>
{
    
}