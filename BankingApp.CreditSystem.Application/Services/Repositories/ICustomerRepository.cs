using BankingApp.CreditSystem.Core.Repositories;
using BankingApp.CreditSystem.Domain.Entities;

namespace BankingApp.CreditSystem.Application.Services.Repositories;

public interface ICustomerRepository : IRepository<Customer, Guid>
{
    Task<Customer?> GetCustomerWithDetailsAsync(Guid customerId, CancellationToken cancellationToken = default);
    Task<IList<Customer>> GetActiveCustomersAsync(CancellationToken cancellationToken = default);
    Task<bool> IsEmailExistsAsync(string email, Guid? excludeCustomerId = null, CancellationToken cancellationToken = default);
    Task<bool> IsPhoneNumberExistsAsync(string phoneNumber, Guid? excludeCustomerId = null, CancellationToken cancellationToken = default);
} 