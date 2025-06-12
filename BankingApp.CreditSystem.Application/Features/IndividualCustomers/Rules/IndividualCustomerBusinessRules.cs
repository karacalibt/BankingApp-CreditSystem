using BankingApp.CreditSystem.Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;
using BankingApp.CreditSystem.Application.Features.IndividualCustomers.Services;
using BankingApp.CreditSystem.Application.Features.IndividualCustomers.Validators;

namespace BankingApp.CreditSystem.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IndividualCustomerValidator _validator;
    private readonly IndividualCustomerExistenceChecker _existenceChecker;

    public IndividualCustomerBusinessRules(
        IndividualCustomerValidator validator,
        IndividualCustomerExistenceChecker existenceChecker)
    {
        _validator = validator;
        _existenceChecker = existenceChecker;
    }

    public async Task ValidateCreateRequestAsync(CreateIndividualCustomerCommand request)
    {
        // Domain validation
        _validator.ValidateNationalId(request.NationalId);
        _validator.ValidateAge(request.DateOfBirth);

        // Business rules validation
        await _existenceChecker.CheckIfNationalIdExistsAsync(request.NationalId);
        await _existenceChecker.CheckIfEmailExistsAsync(request.Email);
        await _existenceChecker.CheckIfPhoneNumberExistsAsync(request.PhoneNumber);
    }

    // Backward compatibility - bu metodlar deprecate edilecek
    [Obsolete("Use ValidateCreateRequestAsync instead. This method will be removed in future versions.")]
    public async Task CheckIfNationalIdExistsAsync(string nationalId, Guid? excludeCustomerId = null)
    {
        await _existenceChecker.CheckIfNationalIdExistsAsync(nationalId, excludeCustomerId);
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
    public void CheckCustomerAge(DateTime dateOfBirth)
    {
        _validator.ValidateAge(dateOfBirth);
    }

    [Obsolete("Use ValidateCreateRequestAsync instead. This method will be removed in future versions.")]
    public void ValidateNationalId(string nationalId)
    {
        _validator.ValidateNationalId(nationalId);
    }
} 