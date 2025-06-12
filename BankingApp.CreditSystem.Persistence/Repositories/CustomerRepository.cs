using BankingApp.CreditSystem.Application.Services.Repositories;
using BankingApp.CreditSystem.Domain.Entities;
using BankingApp.CreditSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.CreditSystem.Persistence.Repositories;

public class CustomerRepository : EfRepository<Customer, Guid>, ICustomerRepository
{
    public CustomerRepository(BankingContext context) : base(context)
    {
    }

    public async Task<Customer?> GetCustomerWithDetailsAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(c => c.Id == customerId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IList<Customer>> GetActiveCustomersAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(c => c.IsActive && c.DeletedDate == null)
            .OrderBy(c => c.CreatedDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsEmailExistsAsync(string email, Guid? excludeCustomerId = null, CancellationToken cancellationToken = default)
    {
        var query = DbSet.Where(c => c.Email == email && c.DeletedDate == null);
        
        if (excludeCustomerId.HasValue)
        {
            query = query.Where(c => c.Id != excludeCustomerId.Value);
        }
        
        return await query.AnyAsync(cancellationToken);
    }

    public async Task<bool> IsPhoneNumberExistsAsync(string phoneNumber, Guid? excludeCustomerId = null, CancellationToken cancellationToken = default)
    {
        var query = DbSet.Where(c => c.PhoneNumber == phoneNumber && c.DeletedDate == null);
        
        if (excludeCustomerId.HasValue)
        {
            query = query.Where(c => c.Id != excludeCustomerId.Value);
        }
        
        return await query.AnyAsync(cancellationToken);
    }
} 