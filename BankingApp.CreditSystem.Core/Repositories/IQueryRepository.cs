using System.Linq.Expressions;

namespace BankingApp.CreditSystem.Core.Repositories;

public interface IQueryRepository<TEntity, TId> where TEntity : Entity<TId>
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
} 