using BankingApp.CreditSystem.Core.Repositories;
using BankingApp.CreditSystem.Domain.Entities;

namespace BankingApp.CreditSystem.Application.Services.Repositories;

public interface ICorporateCustomerRepository : IRepository<CorporateCustomer, Guid>
{
    Task<CorporateCustomer?> GetByTaxNumberAsync(string taxNumber, CancellationToken cancellationToken = default);
    Task<CorporateCustomer?> GetByCompanyRegistrationNumberAsync(string registrationNumber, CancellationToken cancellationToken = default);
    Task<bool> IsTaxNumberExistsAsync(string taxNumber, Guid? excludeCustomerId = null, CancellationToken cancellationToken = default);
    Task<bool> IsCompanyRegistrationNumberExistsAsync(string registrationNumber, Guid? excludeCustomerId = null, CancellationToken cancellationToken = default);
    Task<IList<CorporateCustomer>> SearchByCompanyNameAsync(string searchTerm, CancellationToken cancellationToken = default);
    Task<IList<CorporateCustomer>> GetCompaniesByFoundationYearAsync(int year, CancellationToken cancellationToken = default);
} 