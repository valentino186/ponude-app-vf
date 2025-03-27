using System.Linq.Expressions;

namespace PonudeApp.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IList<TEntity>> GetPaginationAsync(int page, int pageSize, CancellationToken cancellationToken = default);

    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    TEntity Create(TEntity entity);

    TEntity Delete(TEntity entity);
}
