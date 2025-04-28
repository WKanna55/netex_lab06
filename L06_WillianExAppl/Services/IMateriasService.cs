using L06_WillianExAppl.Dtos.Materias;
using L06_WillianExAppl.Entities;

namespace L06_WillianExAppl.Services;

public interface IMateriasService : 
    IServiceBase<Materias, MateriasGetDto, MateriasPostDto, MateriasPutDto>
{
    
}