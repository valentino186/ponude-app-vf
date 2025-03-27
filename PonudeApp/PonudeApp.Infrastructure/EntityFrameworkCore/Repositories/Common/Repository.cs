using Microsoft.EntityFrameworkCore;
using PonudeApp.Domain.Common;
using PonudeApp.Domain.Interfaces;
using System.Linq.Expressions;

namespace PonudeApp.Infrastructure.EntityFrameworkCore.Repositories.Common;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<Guid>
{
    protected readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public TEntity Create(TEntity entity)
    {
        _context.Add(entity);

        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        _context.Remove(entity);

        return entity;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<IList<TEntity>> GetPaginationAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}
