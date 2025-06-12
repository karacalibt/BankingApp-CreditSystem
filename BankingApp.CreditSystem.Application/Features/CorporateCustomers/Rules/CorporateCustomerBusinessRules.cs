using BankingApp.CreditSystem.Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;
using BankingApp.CreditSystem.Application.Features.CorporateCustomers.Services;
using BankingApp.CreditSystem.Application.Features.CorporateCustomers.Validators;

namespace BankingApp.CreditSystem.Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules
{
    private readonly CorporateCustomerValidator _validator;
    private readonly CorporateCustomerExistenceChecker _existenceChecker;

    public CorporateCustomerBusinessRules(
        CorporateCustomerValidator validator,
        CorporateCustomerExistenceChecker existenceChecker)
    {
        _validator = validator;
        _existenceChecker = existenceChecker;
    }

    public async Task ValidateCreateRequestAsync(CreateCorporateCustomerCommand request)
    {
        // Domain validation
        _validator.ValidateTaxNumber(request.TaxNumber);
        _validator.ValidateCompanyAge(request.CompanyFoundationDate);

        // Business rules validation
        await _existenceChecker.CheckIfTaxNumberExistsAsync(request.TaxNumber);
        await _existenceChecker.CheckIfEmailExistsAsync(request.Email);
        await _existenceChecker.CheckIfPhoneNumberExistsAsync(request.PhoneNumber);
        await _existenceChecker.CheckIfRegistrationNumberExistsAsync(request.CompanyRegistrationNumber);
    }

    // Backward compatibility - bu metodlar deprecate edilecek
    [Obsolete("Use ValidateCreateRequestAsync instead. This method will be removed in future versions.")]
    public async Task CheckIfTaxNumberExistsAsync(string taxNumber, Guid? excludeCustomerId = null)
    {
        await _existenceChecker.CheckIfTaxNumberExistsAsync(taxNumber, excludeCustomerId);
    }

    [Obsolete("Use ValidateCreateRequestAsync instead. This method will be removed in future versions.")]
    public async Task CheckIfEmailExistsAsync(string email, Guid? excludeCustomerId = null)
    {
        await _existenceChecker.CheckIfEmailExistsAsync(email, excludeCustomerId);
    }

    [Obsolete("Use ValidateCreateRequestAsync instead. This method will be removed in future versions.")]
    public async Task CheckIfPhoneNumberExistsAsync(string phoneNumber, Guid? excludeCustomerId = null)
    {
        await _existenceChecker.CheckIfPhoneNumberExistsAsync(phoneNumber, excludeCustomerId);
    }

    [Obsolete("Use ValidateCreateRequestAsync instead. This method will be removed in future versions.")]
    public async Task CheckIfRegistrationNumberExistsAsync(string registrationNumber, Guid? excludeCustomerId = null)
    {
        await _existenceChecker.CheckIfRegistrationNumberExistsAsync(registrationNumber, excludeCustomerId);
    }

    [Obsolete("Use ValidateCreateRequestAsync instead. This method will be removed in future versions.")]
    public void CheckCompanyAge(DateTime companyFoundationDate)
    {
        _validator.ValidateCompanyAge(companyFoundationDate);
    }

    [Obsolete("Use ValidateCreateRequestAsync instead. This method will be removed in future versions.")]
    public void ValidateTaxNumber(string taxNumber)
    {
        _validator.ValidateTaxNumber(taxNumber);
    }
} 