using Microsoft.EntityFrameworkCore;
using PanoptiBooru.Server.Data;

namespace PanoptiBooru.Server.Repositories.Core;

public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
{
    // ReSharper disable once MemberCanBePrivate.Global
    protected readonly PanoptiBooruContext Context;
    protected DbSet<TEntity> Set => Context.Set<TEntity>();

    protected RepositoryBase(PanoptiBooruContext context)
    {
        Context = context;
    }

    public TEntity? GetById(TKey id)
    {
        return Set.Find(id);
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await Set.FindAsync(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return Set.AsEnumerable();
    }

    public IAsyncEnumerable<TEntity> GetAllAsync()
    {
        return Set.AsAsyncEnumerable();
    }
}
