using System.Linq.Expressions;
using DemoCICD.Domain.Abstractions.Entities;
using DemoCICD.Domain.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;

namespace DemoCICD.Persistence.Repositories;

public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>, IDisposable
    where TEntity : DomainEntity<TKey>
{
    private readonly ApplicationDbContext _context;

    public RepositoryBase(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }

    public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>>? predicate = null,
        params Expression<Func<TEntity, object>>[] includesProperties)
    {
        IQueryable<TEntity> items = _context.Set<TEntity>();
        if (includesProperties != null)
            foreach (var includesProperty in includesProperties)
                items = items.Include(includesProperty);

        if (predicate is not null) items = items.Where(predicate);
        return items;
    }

    public TEntity FindById(TKey id, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        return FindAll(null, includeProperties).SingleOrDefault(x => x.Id.Equals(id));
    }

    public TEntity FinsSingle(Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        return FindAll(null, includeProperties).SingleOrDefault(predicate);
    }

    public void Add(TEntity entity)
    {
        _context.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void RemoveMultiple(List<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }
}