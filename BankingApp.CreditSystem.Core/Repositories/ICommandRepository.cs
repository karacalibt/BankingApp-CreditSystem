namespace BankingApp.CreditSystem.Core.Repositories;

public interface ICommandRepository<TEntity, TId> where TEntity : Entity<TId>
{
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