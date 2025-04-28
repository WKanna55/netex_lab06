namespace L06_WillianExAppl.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUsuariosRepository Usuarios { get; }
    
    IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> Complete();
}