using System.Linq.Expressions;

namespace BankingApp.CreditSystem.Core.Repositories;

public interface IPaginationRepository<TEntity, TId> where TEntity : Entity<TId>
{
    Task<PagedResult<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>>? predicate = null, 
        int pageIndex = 0, int pageSize = 10, 
        CancellationToken cancellationToken = default);
    
    Task<PagedResult<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>>? predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int pageIndex = 0, int pageSize = 10, 
        CancellationToken cancellationToken = default, 
        params Expression<Func<TEntity, object>>[] includes);
} 