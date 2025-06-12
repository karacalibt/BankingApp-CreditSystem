using BankingApp.CreditSystem.Core.Repositories;
using BankingApp.CreditSystem.Domain.Entities;

namespace BankingApp.CreditSystem.Application.Services.Repositories;

public interface IIndividualCustomerRepository : IRepository<IndividualCustomer, Guid>
{
    Task<IndividualCustomer?> GetByNationalIdAsync(string nationalId, CancellationToken cancellationToken = default);
    Task<bool> IsNationalIdExistsAsync(string nationalId, Guid? excludeCustomerId = null, CancellationToken cancellationToken = default);
    Task<IList<IndividualCustomer>> GetCustomersByAgeRangeAsync(int minAge, int maxAge, CancellationToken cancellationToken = default);
    Task<IList<IndividualCustomer>> SearchByNameAsync(string searchTerm, CancellationToken cancellationToken = default);
} 