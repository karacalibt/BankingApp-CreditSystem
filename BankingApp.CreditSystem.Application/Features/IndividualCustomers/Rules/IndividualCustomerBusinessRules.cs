using BankingApp.CreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingApp.CreditSystem.Application.Services.Repositories;

namespace BankingApp.CreditSystem.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
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

    public void CheckCustomerAge(DateTime dateOfBirth)
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

        // TC Kimlik No algoritması kontrolü
        if (!IsValidTurkishNationalId(nationalId))
        {
            throw new ArgumentException(IndividualCustomerConstants.ValidationMessages.NationalIdInvalid);
        }
    }

    private static bool IsValidTurkishNationalId(string nationalId)
    {
        if (nationalId.Length != 11 || !nationalId.All(char.IsDigit))
            return false;

        var digits = nationalId.Select(c => int.Parse(c.ToString())).ToArray();

        // İlk rakam 0 olamaz
        if (digits[0] == 0)
            return false;

        // 10. rakam = ((1. rakam + 3. rakam + 5. rakam + 7. rakam + 9. rakam) * 7 - (2. rakam + 4. rakam + 6. rakam + 8. rakam)) mod 10
        var oddSum = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
        var evenSum = digits[1] + digits[3] + digits[5] + digits[7];
        var tenthDigit = ((oddSum * 7) - evenSum) % 10;

        if (digits[9] != tenthDigit)
            return false;

        // 11. rakam = (1. rakam + 2. rakam + ... + 10. rakam) mod 10
        var totalSum = digits.Take(10).Sum();
        var eleventhDigit = totalSum % 10;

        return digits[10] == eleventhDigit;
    }
} 