using System.Linq.Expressions;

namespace BankingApp.CreditSystem.Core.Repositories;

/// <summary>
/// Composed repository interface following Interface Segregation Principle (ISP)
/// </summary>
public interface IRepository<TEntity, TId> : 
    IQueryRepository<TEntity, TId>, 
    ICommandRepository<TEntity, TId>,
    IAggregationRepository<TEntity, TId>,
    IPaginationRepository<TEntity, TId>
    where TEntity : Entity<TId>
{
} 