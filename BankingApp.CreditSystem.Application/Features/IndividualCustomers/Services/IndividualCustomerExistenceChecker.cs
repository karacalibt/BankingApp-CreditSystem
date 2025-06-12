using BankingApp.CreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingApp.CreditSystem.Application.Services.Repositories;

namespace BankingApp.CreditSystem.Application.Features.IndividualCustomers.Services;

public class IndividualCustomerExistenceChecker
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public IndividualCustomerExistenceChecker(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task CheckIfNationalIdExistsAsync(string nationalId, Guid? excludeCustomerId = null)
    {
        var exists = await _individualCustomerRepository.IsNationalIdExistsAsync(nationalId, excludeCustomerId);
        if (exists)
        {
            throw new InvalidOperationException(IndividualCustomerConstants.BusinessMessages.CustomerAlreadyExists);
        }
    }

    public async Task CheckIfEmailExistsAsync(string email, Guid? excludeCustomerId = null)
    {
        var customer = await _individualCustomerRepository.GetAsync(c => c.Email == email && c.DeletedDate == null);
        if (customer != null && (!excludeCustomerId.HasValue || customer.Id != excludeCustomerId.Value))
        {
            throw new InvalidOperationException(IndividualCustomerConstants.BusinessMessages.EmailAlreadyExists);
        }
    }

    public async Task CheckIfPhoneNumberExistsAsync(string phoneNumber, Guid? excludeCustomerId = null)
    {
        var customer = await _individualCustomerRepository.GetAsync(c => c.PhoneNumber == phoneNumber && c.DeletedDate == null);
        if (customer != null && (!excludeCustomerId.HasValue || customer.Id != excludeCustomerId.Value))
        {
            throw new InvalidOperationException(IndividualCustomerConstants.BusinessMessages.PhoneNumberAlreadyExists);
        }
    }
} 