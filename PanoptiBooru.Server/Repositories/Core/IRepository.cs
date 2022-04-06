namespace PanoptiBooru.Server.Repositories.Core;

public interface IRepository<TEntity, TKey> where TEntity : class
{
    TEntity? GetById(TKey id);

    Task<TEntity?> GetByIdAsync(TKey id);

    IEnumerable<TEntity> GetAll();

    IAsyncEnumerable<TEntity> GetAllAsync();
}

public interface IRepository<TEntity, TKey0, TKey1>
{
    TEntity GetById(TKey0 id0, TKey1 id1);

    IEnumerable<TEntity> GetAll();
    
    IAsyncEnumerable<TEntity> GetAllAsync();
}
