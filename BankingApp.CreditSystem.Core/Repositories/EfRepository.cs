using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankingApp.CreditSystem.Core.Repositories;

public class EfRepository<TEntity, TId> : IRepository<TEntity, TId> 
    where TEntity : Entity<TId>
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public EfRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> Query()
    {
        return _dbSet.AsQueryable();
    }

    public virtual IQueryable<TEntity> QueryNoTracking()
    {
        return _dbSet.AsNoTracking();
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(new object[] { id! }, cancellationToken);
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, params Expression<Func<TEntity, object>>[] includes)
    {
        return await GetByIdAsync(id, CancellationToken.None, includes);
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _dbSet.AsQueryable();
        
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }
        
        return await query.FirstOrDefaultAsync(entity => entity.Id!.Equals(id), cancellationToken);
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
    {
        return await GetAsync(predicate, CancellationToken.None, includes);
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _dbSet.AsQueryable();
        
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }
        
        return await query.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public virtual async Task<IList<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        return await GetAllAsync(CancellationToken.None, includes);
    }

    public virtual async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _dbSet.AsQueryable();
        
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }
        
        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsQueryable();
        
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        
        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includes)
    {
        return await GetListAsync(predicate, CancellationToken.None, includes);
    }

    public virtual async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _dbSet.AsQueryable();
        
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }
        
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        
        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _dbSet.AsQueryable();
        
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }
        
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        
        if (orderBy != null)
        {
            query = orderBy(query);
        }
        
        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<PagedResult<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>>? predicate = null, int pageIndex = 0, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsQueryable();
        
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query.Skip(pageIndex * pageSize)
                               .Take(pageSize)
                               .ToListAsync(cancellationToken);
        
        return new PagedResult<TEntity>(items, totalCount, pageIndex, pageSize);
    }

    public virtual async Task<PagedResult<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int pageIndex = 0, int pageSize = 10, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _dbSet.AsQueryable();
        
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }
        
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        
        if (orderBy != null)
        {
            query = orderBy(query);
        }
        
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query.Skip(pageIndex * pageSize)
                               .Take(pageSize)
                               .ToListAsync(cancellationToken);
        
        return new PagedResult<TEntity>(items, totalCount, pageIndex, pageSize);
    }

    public virtual async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }

    public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.CountAsync(cancellationToken);
    }

    public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.CountAsync(predicate, cancellationToken);
    }

    public virtual async Task<long> LongCountAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.LongCountAsync(cancellationToken);
    }

    public virtual async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.LongCountAsync(predicate, cancellationToken);
    }

    public virtual async Task<TResult?> MaxAsync<TResult>(Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken = default)
    {
        return await _dbSet.MaxAsync(selector, cancellationToken);
    }

    public virtual async Task<TResult?> MinAsync<TResult>(Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken = default)
    {
        return await _dbSet.MinAsync(selector, cancellationToken);
    }

    public virtual async Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector, CancellationToken cancellationToken = default)
    {
        return await _dbSet.SumAsync(selector, cancellationToken);
    }

    public virtual async Task<double> AverageAsync(Expression<Func<TEntity, int>> selector, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AverageAsync(selector, cancellationToken);
    }

    public virtual async Task<double> AverageAsync(Expression<Func<TEntity, double>> selector, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AverageAsync(selector, cancellationToken);
    }

    public virtual async Task<decimal> AverageAsync(Expression<Func<TEntity, decimal>> selector, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AverageAsync(selector, cancellationToken);
    }

    public virtual TEntity Add(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        
        return _dbSet.Add(entity).Entity;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        
        var entityEntry = await _dbSet.AddAsync(entity, cancellationToken);
        return entityEntry.Entity;
    }

    public virtual void AddRange(IEnumerable<TEntity> entities)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));
        
        _dbSet.AddRange(entities);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));
        
        await _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    public virtual TEntity Update(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        
        entity.UpdatedDate = DateTime.UtcNow;
        return _dbSet.Update(entity).Entity;
    }

    public virtual void UpdateRange(IEnumerable<TEntity> entities)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));
        
        foreach (var entity in entities)
        {
            entity.UpdatedDate = DateTime.UtcNow;
        }
        
        _dbSet.UpdateRange(entities);
    }

    public virtual void Delete(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        
        _dbSet.Remove(entity);
    }

    public virtual void Delete(TId id)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
        {
            Delete(entity);
        }
    }

    public virtual void DeleteRange(IEnumerable<TEntity> entities)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));
        
        _dbSet.RemoveRange(entities);
    }

    public virtual void DeleteRange(IEnumerable<TId> ids)
    {
        if (ids == null) throw new ArgumentNullException(nameof(ids));
        
        var entities = _dbSet.Where(e => ids.Contains(e.Id)).ToList();
        if (entities.Any())
        {
            DeleteRange(entities);
        }
    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
} 