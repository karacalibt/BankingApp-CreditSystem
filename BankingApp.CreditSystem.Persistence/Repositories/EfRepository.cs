using System.Linq.Expressions;
using BankingApp.CreditSystem.Core.Repositories;
using BankingApp.CreditSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.CreditSystem.Persistence.Repositories;

public class EfRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : Entity<TId>
{
    protected readonly BankingContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public EfRepository(BankingContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public IQueryable<TEntity> Query()
    {
        return DbSet.AsQueryable();
    }

    public IQueryable<TEntity> QueryNoTracking()
    {
        return DbSet.AsNoTracking();
    }

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(TId id, params Expression<Func<TEntity, object>>[] includes)
    {
        return await GetByIdAsync(id, CancellationToken.None, includes);
    }

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = DbSet.AsQueryable();
        
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        
        return await query.FirstOrDefaultAsync(e => e.Id!.Equals(id), cancellationToken);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
    {
        return await GetAsync(predicate, CancellationToken.None, includes);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = DbSet.AsQueryable();
        
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        
        return await query.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.ToListAsync(cancellationToken);
    }

    public async Task<IList<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        return await GetAllAsync(CancellationToken.None, includes);
    }

    public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = DbSet.AsQueryable();
        
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includes)
    {
        return await GetListAsync(predicate, CancellationToken.None, includes);
    }

    public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = DbSet.AsQueryable();
        
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
        CancellationToken cancellationToken = default, 
        params Expression<Func<TEntity, object>>[] includes)
    {
        var query = DbSet.AsQueryable();
        
        foreach (var include in includes)
        {
            query = query.Include(include);
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

    public async Task<PagedResult<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>>? predicate = null, 
        int pageIndex = 0, int pageSize = 10, 
        CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        
        return new PagedResult<TEntity>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<PagedResult<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>>? predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int pageIndex = 0, int pageSize = 10, 
        CancellationToken cancellationToken = default, 
        params Expression<Func<TEntity, object>>[] includes)
    {
        var query = DbSet.AsQueryable();
        
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        
        var totalCount = await query.CountAsync(cancellationToken);
        
        if (orderBy != null)
        {
            query = orderBy(query);
        }
        
        var items = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        
        return new PagedResult<TEntity>(items, totalCount, pageIndex, pageSize);
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(predicate, cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.CountAsync(cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.CountAsync(predicate, cancellationToken);
    }

    public async Task<long> LongCountAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.LongCountAsync(cancellationToken);
    }

    public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.LongCountAsync(predicate, cancellationToken);
    }

    public async Task<TResult?> MaxAsync<TResult>(Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken = default)
    {
        return await DbSet.MaxAsync(selector, cancellationToken);
    }

    public async Task<TResult?> MinAsync<TResult>(Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken = default)
    {
        return await DbSet.MinAsync(selector, cancellationToken);
    }

    public async Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector, CancellationToken cancellationToken = default)
    {
        return await DbSet.SumAsync(selector, cancellationToken);
    }

    public async Task<double> AverageAsync(Expression<Func<TEntity, int>> selector, CancellationToken cancellationToken = default)
    {
        return await DbSet.AverageAsync(selector, cancellationToken);
    }

    public async Task<double> AverageAsync(Expression<Func<TEntity, double>> selector, CancellationToken cancellationToken = default)
    {
        return await DbSet.AverageAsync(selector, cancellationToken);
    }

    public async Task<decimal> AverageAsync(Expression<Func<TEntity, decimal>> selector, CancellationToken cancellationToken = default)
    {
        return await DbSet.AverageAsync(selector, cancellationToken);
    }

    public TEntity Add(TEntity entity)
    {
        return DbSet.Add(entity).Entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entityEntry = await DbSet.AddAsync(entity, cancellationToken);
        return entityEntry.Entity;
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        DbSet.AddRange(entities);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await DbSet.AddRangeAsync(entities, cancellationToken);
    }

    public TEntity Update(TEntity entity)
    {
        return DbSet.Update(entity).Entity;
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        DbSet.UpdateRange(entities);
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public void Delete(TId id)
    {
        var entity = DbSet.Find(id);
        if (entity != null)
        {
            DbSet.Remove(entity);
        }
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);
    }

    public void DeleteRange(IEnumerable<TId> ids)
    {
        var entities = DbSet.Where(e => ids.Contains(e.Id)).ToList();
        DbSet.RemoveRange(entities);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await Context.SaveChangesAsync(cancellationToken);
    }
} 