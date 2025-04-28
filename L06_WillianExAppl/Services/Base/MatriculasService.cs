using L06_WillianExAppl.Dtos.Matriculas;
using L06_WillianExAppl.Entities;
using L06_WillianExAppl.Interfaces;
using Mapster;

namespace L06_WillianExAppl.Services.Base;

/*
 * Servicio usando servicio base y mapster
 */
public class MatriculasService : 
    ServiceBase<Matriculas, MatriculasGetDto, MatriculasPostDto, MatriculasPutDto>, IMatriculasService
{
    public MatriculasService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    public override Matriculas MapToEntity(MatriculasPostDto dto) => dto.Adapt<Matriculas>();
    public override MatriculasGetDto MapToGetDto(Matriculas entity) => entity.Adapt<MatriculasGetDto>();
    public override void MapUpdate(Matriculas entity, MatriculasPutDto dto) => dto.Adapt(entity); // mapea sobre el objeto existent
}