using BankingApp.CreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingApp.CreditSystem.Application.Services.Repositories;

namespace BankingApp.CreditSystem.Application.Features.CorporateCustomers.Services;

public class CorporateCustomerExistenceChecker
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public CorporateCustomerExistenceChecker(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task CheckIfTaxNumberExistsAsync(string taxNumber, Guid? excludeCustomerId = null)
    {
        var exists = await _corporateCustomerRepository.IsTaxNumberExistsAsync(taxNumber, excludeCustomerId);
        if (exists)
        {
            throw new InvalidOperationException(CorporateCustomerConstants.BusinessMessages.CustomerAlreadyExists);
        }
    }

    public async Task CheckIfEmailExistsAsync(string email, Guid? excludeCustomerId = null)
    {
        var customer = await _corporateCustomerRepository.GetAsync(c => c.Email == email && c.DeletedDate == null);
        if (customer != null && (!excludeCustomerId.HasValue || customer.Id != excludeCustomerId.Value))
        {
            throw new InvalidOperationException(CorporateCustomerConstants.BusinessMessages.EmailAlreadyExists);
        }
    }

    public async Task CheckIfPhoneNumberExistsAsync(string phoneNumber, Guid? excludeCustomerId = null)
    {
        var customer = await _corporateCustomerRepository.GetAsync(c => c.PhoneNumber == phoneNumber && c.DeletedDate == null);
        if (customer != null && (!excludeCustomerId.HasValue || customer.Id != excludeCustomerId.Value))
        {
            throw new InvalidOperationException(CorporateCustomerConstants.BusinessMessages.PhoneNumberAlreadyExists);
        }
    }

    public async Task CheckIfRegistrationNumberExistsAsync(string registrationNumber, Guid? excludeCustomerId = null)
    {
        var exists = await _corporateCustomerRepository.IsCompanyRegistrationNumberExistsAsync(registrationNumber, excludeCustomerId);
        if (exists)
        {
            throw new InvalidOperationException(CorporateCustomerConstants.BusinessMessages.RegistrationNumberAlreadyExists);
        }
    }
} 