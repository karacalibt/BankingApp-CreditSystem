using System.Linq.Expressions;

namespace BankingApp.CreditSystem.Core.Repositories;

public interface IRepository<TEntity, TId> where TEntity : Entity<TId>
{
    IQueryable<TEntity> Query();
    IQueryable<TEntity> QueryNoTracking();
    
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TId id, params Expression<Func<TEntity, object>>[] includes);
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes);
    
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes);
    
    Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IList<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
    Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes);
    
    Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default);
    Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includes);
    Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes);
    
    Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
        CancellationToken cancellationToken = default, 
        params Expression<Func<TEntity, object>>[] includes);
    
    Task<PagedResult<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>>? predicate = null, 
        int pageIndex = 0, int pageSize = 10, 
        CancellationToken cancellationToken = default);
    
    Task<PagedResult<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>>? predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int pageIndex = 0, int pageSize = 10, 
        CancellationToken cancellationToken = default, 
        params Expression<Func<TEntity, object>>[] includes);
    
    Task<bool> AnyAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task<int> CountAsync(CancellationToken cancellationToken = default);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task<long> LongCountAsync(CancellationToken cancellationToken = default);
    Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task<TResult?> MaxAsync<TResult>(Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken = default);
    Task<TResult?> MinAsync<TResult>(Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken = default);
    Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector, CancellationToken cancellationToken = default);
    Task<double> AverageAsync(Expression<Func<TEntity, int>> selector, CancellationToken cancellationToken = default);
    Task<double> AverageAsync(Expression<Func<TEntity, double>> selector, CancellationToken cancellationToken = default);
    Task<decimal> AverageAsync(Expression<Func<TEntity, decimal>> selector, CancellationToken cancellationToken = default);
    
    TEntity Add(TEntity entity);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void AddRange(IEnumerable<TEntity> entities);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    
    TEntity Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    
    void Delete(TEntity entity);
    void Delete(TId id);
    void DeleteRange(IEnumerable<TEntity> entities);
    void DeleteRange(IEnumerable<TId> ids);
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
} 