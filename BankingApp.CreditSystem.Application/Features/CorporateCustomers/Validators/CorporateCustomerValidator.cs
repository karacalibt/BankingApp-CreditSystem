using BankingApp.CreditSystem.Application.Features.CorporateCustomers.Constants;

namespace BankingApp.CreditSystem.Application.Features.CorporateCustomers.Validators;

public class CorporateCustomerValidator
{
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

        if (!IsValidTurkishTaxNumber(taxNumber))
        {
            throw new ArgumentException(CorporateCustomerConstants.ValidationMessages.TaxNumberInvalid);
        }
    }

    public void ValidateCompanyAge(DateTime companyFoundationDate)
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