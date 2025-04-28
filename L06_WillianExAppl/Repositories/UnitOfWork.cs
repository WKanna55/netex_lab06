using System.Collections;
using L06_WillianExAppl.Data;
using L06_WillianExAppl.Interfaces;

namespace L06_WillianExAppl.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable? _repositories;
    private readonly ApplicationDbContext _context;
    public IUsuariosRepository Usuarios { get;  }

    public UnitOfWork(ApplicationDbContext context,
        IUsuariosRepository usuariosRepository)
    {
        _context = context;
        _repositories = new Hashtable();
        Usuarios = usuariosRepository;
    }
    
    public Task<int> Complete()
    {
        return _context.SaveChangesAsync();
    }
    
    /*
     * Funcion para usar un repositorio generico con cualquier entidad
     */
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity);

        if (_repositories.ContainsKey(type))
        {
            return (IRepository<TEntity>)_repositories[type];
        }

        var repositoryType = typeof(Repository<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

        if (repositoryInstance != null)
        {
            _repositories.Add(type, repositoryInstance);
            return (IRepository<TEntity>)repositoryInstance;
        }
        
        throw new Exception($"No se pudo crear el repositorio para este tipo {type}");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    
}