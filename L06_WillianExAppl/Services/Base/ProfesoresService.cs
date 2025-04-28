using L06_WillianExAppl.Dtos.Profesores;
using L06_WillianExAppl.Entities;
using L06_WillianExAppl.Interfaces;
using Mapster;

namespace L06_WillianExAppl.Services.Base;
/*
 * Servicio convencional -> sin usar servicio base y usando mapster
 */
public class ProfesoresService : 
    ServiceBase<Profesores, ProfesoresGetDto, ProfesoresPostDto, ProfesoresPutDto>, IProfesoresService
{
    public ProfesoresService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public override Profesores MapToEntity(ProfesoresPostDto dto) => dto.Adapt<Profesores>();

    public override ProfesoresGetDto MapToGetDto(Profesores entity) => entity.Adapt<ProfesoresGetDto>();

    public override void MapUpdate(Profesores entity, ProfesoresPutDto dto) => dto.Adapt(entity);
}