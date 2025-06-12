using BankingApp.CreditSystem.Application.Features.IndividualCustomers.Constants;

namespace BankingApp.CreditSystem.Application.Features.IndividualCustomers.Validators;

public class IndividualCustomerValidator
{
    public void ValidateNationalId(string nationalId)
    {
        if (string.IsNullOrWhiteSpace(nationalId) || nationalId.Length != IndividualCustomerConstants.Rules.NationalIdLength)
        {
            throw new ArgumentException(IndividualCustomerConstants.ValidationMessages.NationalIdLength);
        }

        if (!nationalId.All(char.IsDigit))
        {
            throw new ArgumentException(IndividualCustomerConstants.ValidationMessages.NationalIdInvalid);
        }

        if (!IsValidTurkishNationalId(nationalId))
        {
            throw new ArgumentException(IndividualCustomerConstants.ValidationMessages.NationalIdInvalid);
        }
    }

    public void ValidateAge(DateTime dateOfBirth)
    {
        var age = DateTime.Today.Year - dateOfBirth.Year;
        if (DateTime.Today.DayOfYear < dateOfBirth.DayOfYear)
            age--;

        if (age < IndividualCustomerConstants.Rules.MinimumAge)
        {
            throw new ArgumentException(IndividualCustomerConstants.ValidationMessages.AgeMinimum);
        }

        if (age > IndividualCustomerConstants.Rules.MaximumAge)
        {
            throw new ArgumentException(IndividualCustomerConstants.ValidationMessages.AgeMaximum);
        }
    }

    private static bool IsValidTurkishNationalId(string nationalId)
    {
        if (nationalId.Length != 11 || !nationalId.All(char.IsDigit))
            return false;

        var digits = nationalId.Select(c => int.Parse(c.ToString())).ToArray();

        if (digits[0] == 0)
            return false;

        var oddSum = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
        var evenSum = digits[1] + digits[3] + digits[5] + digits[7];
        var tenthDigit = ((oddSum * 7) - evenSum) % 10;

        if (digits[9] != tenthDigit)
            return false;

        var totalSum = digits.Take(10).Sum();
        var eleventhDigit = totalSum % 10;

        return digits[10] == eleventhDigit;
    }
} 