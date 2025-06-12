using BankingApp.CreditSystem.Application.Services.Repositories;
using BankingApp.CreditSystem.Domain.Entities;
using BankingApp.CreditSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.CreditSystem.Persistence.Repositories;

public class IndividualCustomerRepository : EfRepository<IndividualCustomer, Guid>, IIndividualCustomerRepository
{
    public IndividualCustomerRepository(BankingContext context) : base(context)
    {
    }

    public async Task<IndividualCustomer?> GetByNationalIdAsync(string nationalId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(ic => ic.NationalId == nationalId && ic.DeletedDate == null)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> IsNationalIdExistsAsync(string nationalId, Guid? excludeCustomerId = null, CancellationToken cancellationToken = default)
    {
        var query = DbSet.Where(ic => ic.NationalId == nationalId && ic.DeletedDate == null);
        
        if (excludeCustomerId.HasValue)
        {
            query = query.Where(ic => ic.Id != excludeCustomerId.Value);
        }
        
        return await query.AnyAsync(cancellationToken);
    }

    public async Task<IList<IndividualCustomer>> GetCustomersByAgeRangeAsync(int minAge, int maxAge, CancellationToken cancellationToken = default)
    {
        var today = DateTime.Today;
        var maxBirthDate = today.AddYears(-minAge);
        var minBirthDate = today.AddYears(-maxAge - 1);
        
        return await DbSet
            .Where(ic => ic.DateOfBirth >= minBirthDate && 
                        ic.DateOfBirth <= maxBirthDate && 
                        ic.IsActive && 
                        ic.DeletedDate == null)
            .OrderBy(ic => ic.FirstName)
            .ThenBy(ic => ic.LastName)
            .ToListAsync(cancellationToken);
    }

    public async Task<IList<IndividualCustomer>> SearchByNameAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        var normalizedSearchTerm = searchTerm.ToLower().Trim();
        
        return await DbSet
            .Where(ic => (ic.FirstName.ToLower().Contains(normalizedSearchTerm) || 
                         ic.LastName.ToLower().Contains(normalizedSearchTerm) ||
                         (ic.FirstName + " " + ic.LastName).ToLower().Contains(normalizedSearchTerm)) &&
                        ic.IsActive && 
                        ic.DeletedDate == null)
            .OrderBy(ic => ic.FirstName)
            .ThenBy(ic => ic.LastName)
            .ToListAsync(cancellationToken);
    }
} 