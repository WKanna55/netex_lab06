using L06_WillianExAppl.Interfaces;

namespace L06_WillianExAppl.Services.Base;

public abstract class ServiceBase<TEntity, TGetDto, TPostDto, TPutDto> :
    IServiceBase<TEntity, TGetDto, TPostDto, TPutDto> where TEntity : class
{
    protected readonly IUnitOfWork _unitOfWork;

    public ServiceBase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    // Mapeo que deben implementar los servicios especificos
    public abstract TEntity MapToEntity(TPostDto entity);
    public abstract TGetDto MapToGetDto(TEntity entity);
    public abstract void MapUpdate(TEntity entity, TPutDto dto);
    
    public virtual async Task<IEnumerable<TGetDto>> GetAll()
    {
        var entities = await _unitOfWork.Repository<TEntity>().GetAll();
        return entities.Select(MapToGetDto);
    }

    public virtual async Task<TGetDto?> GetById(int id)
    {
        var entity = await _unitOfWork.Repository<TEntity>().GetById(id);
        return entity == null ? default : MapToGetDto(entity);
    }

    public virtual async Task<TGetDto> Add(TPostDto dto)
    {
        var entity = MapToEntity(dto);
        await _unitOfWork.Repository<TEntity>().Add(entity);
        await _unitOfWork.Complete();
        return MapToGetDto(entity);
    }

    public virtual async Task<bool> Update(int id, TPutDto dto)
    {
        var entity = await _unitOfWork.Repository<TEntity>().GetById(id);
        if (entity == null) 
            return false;
        MapUpdate(entity, dto);
        await _unitOfWork.Repository<TEntity>().Update(entity);
        await _unitOfWork.Complete();
        return true;
    }
    
    public virtual async Task<bool> Delete(int id)
    {
        var deleted = await _unitOfWork.Repository<TEntity>().Delete(id);
        if (!deleted) return false;

        await _unitOfWork.Complete();
        return true;
    }
}