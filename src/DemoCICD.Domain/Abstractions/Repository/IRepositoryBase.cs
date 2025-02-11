using System.Linq.Expressions;

namespace DemoCICD.Domain.Abstractions.Repository;

public interface IRepositoryBase<TEntity, in TKey> where TEntity : class
{
    TEntity FindById(TKey id, params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity FinsSingle(Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties);

    IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>>? predicate = null,
        params Expression<Func<TEntity, object>>[] includeProperties);

    void Add(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    void RemoveMultiple(List<TEntity> entities);
}