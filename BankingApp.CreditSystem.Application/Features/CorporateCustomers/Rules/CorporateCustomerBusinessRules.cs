using BankingApp.CreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingApp.CreditSystem.Application.Services.Repositories;

namespace BankingApp.CreditSystem.Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
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

    public void CheckCompanyAge(DateTime companyFoundationDate)
    {
        var age = DateTime.Today.Year - companyFoundationDate.Year;
        if (DateTime.Today.DayOfYear < companyFoundationDate.DayOfYear)
            age--;

        if (age < CorporateCustomerConstants.Rules.MinimumCompanyAge)
        {
            throw new ArgumentException(CorporateCustomerConstants.ValidationMessages.CompanyAgeMinimum);
        }

        if (age > CorporateCustomerConstants.Rules.MaximumCompanyAge)
        {
            throw new ArgumentException(CorporateCustomerConstants.ValidationMessages.CompanyAgeMaximum);
        }
    }

    public void ValidateTaxNumber(string taxNumber)
    {
        if (string.IsNullOrWhiteSpace(taxNumber) || taxNumber.Length != CorporateCustomerConstants.Rules.TaxNumberLength)
        {
            throw new ArgumentException(CorporateCustomerConstants.ValidationMessages.TaxNumberLength);
        }

        if (!taxNumber.All(char.IsDigit))
        {
            throw new ArgumentException(CorporateCustomerConstants.ValidationMessages.TaxNumberInvalid);
        }

        // Türkiye Vergi Numarası kontrol algoritması
        if (!IsValidTurkishTaxNumber(taxNumber))
        {
            throw new ArgumentException(CorporateCustomerConstants.ValidationMessages.TaxNumberInvalid);
        }
    }

    private static bool IsValidTurkishTaxNumber(string taxNumber)
    {
        if (taxNumber.Length != 10 || !taxNumber.All(char.IsDigit))
            return false;

        var digits = taxNumber.Select(c => int.Parse(c.ToString())).ToArray();

        var sum = 0;
        for (int i = 0; i < 9; i++)
        {
            var temp = (digits[i] + (10 - i)) % 10;
            sum += temp * (10 - i);
        }

        var lastDigit = sum % 10;
        if (lastDigit != 0)
            lastDigit = 10 - lastDigit;

        return digits[9] == lastDigit;
    }
} 