using L06_WillianExAppl.Dtos.Matriculas;
using L06_WillianExAppl.Entities;

namespace L06_WillianExAppl.Services;

public interface IMatriculasService : 
    IServiceBase<Matriculas, MatriculasGetDto, MatriculasPostDto, MatriculasPutDto>
{
    
}