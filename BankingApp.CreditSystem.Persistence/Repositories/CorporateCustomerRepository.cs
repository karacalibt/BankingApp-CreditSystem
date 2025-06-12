using BankingApp.CreditSystem.Application.Services.Repositories;
using BankingApp.CreditSystem.Domain.Entities;
using BankingApp.CreditSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.CreditSystem.Persistence.Repositories;

public class CorporateCustomerRepository : EfRepository<CorporateCustomer, Guid>, ICorporateCustomerRepository
{
    public CorporateCustomerRepository(BankingContext context) : base(context)
    {
    }

    public async Task<CorporateCustomer?> GetByTaxNumberAsync(string taxNumber, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(cc => cc.TaxNumber == taxNumber && cc.DeletedDate == null)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<CorporateCustomer?> GetByCompanyRegistrationNumberAsync(string registrationNumber, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(cc => cc.CompanyRegistrationNumber == registrationNumber && cc.DeletedDate == null)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> IsTaxNumberExistsAsync(string taxNumber, Guid? excludeCustomerId = null, CancellationToken cancellationToken = default)
    {
        var query = DbSet.Where(cc => cc.TaxNumber == taxNumber && cc.DeletedDate == null);
        
        if (excludeCustomerId.HasValue)
        {
            query = query.Where(cc => cc.Id != excludeCustomerId.Value);
        }
        
        return await query.AnyAsync(cancellationToken);
    }

    public async Task<bool> IsCompanyRegistrationNumberExistsAsync(string registrationNumber, Guid? excludeCustomerId = null, CancellationToken cancellationToken = default)
    {
        var query = DbSet.Where(cc => cc.CompanyRegistrationNumber == registrationNumber && cc.DeletedDate == null);
        
        if (excludeCustomerId.HasValue)
        {
            query = query.Where(cc => cc.Id != excludeCustomerId.Value);
        }
        
        return await query.AnyAsync(cancellationToken);
    }

    public async Task<IList<CorporateCustomer>> SearchByCompanyNameAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        var normalizedSearchTerm = searchTerm.ToLower().Trim();
        
        return await DbSet
            .Where(cc => cc.CompanyName.ToLower().Contains(normalizedSearchTerm) &&
                        cc.IsActive && 
                        cc.DeletedDate == null)
            .OrderBy(cc => cc.CompanyName)
            .ToListAsync(cancellationToken);
    }

    public async Task<IList<CorporateCustomer>> GetCompaniesByFoundationYearAsync(int year, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(cc => cc.CompanyFoundationDate.Year == year &&
                        cc.IsActive && 
                        cc.DeletedDate == null)
            .OrderBy(cc => cc.CompanyName)
            .ToListAsync(cancellationToken);
    }
} 