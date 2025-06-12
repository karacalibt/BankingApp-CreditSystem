using BankingApp.CreditSystem.Application.Features.IndividualCustomers.Constants;
using FluentValidation;

namespace BankingApp.CreditSystem.Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;

public class CreateIndividualCustomerCommandValidator : AbstractValidator<CreateIndividualCustomerCommand>
{
    public CreateIndividualCustomerCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(IndividualCustomerConstants.ValidationMessages.FirstNameRequired)
            .MaximumLength(IndividualCustomerConstants.Rules.FirstNameMaxLength)
            .WithMessage(IndividualCustomerConstants.ValidationMessages.FirstNameMaxLength);

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(IndividualCustomerConstants.ValidationMessages.LastNameRequired)
            .MaximumLength(IndividualCustomerConstants.Rules.LastNameMaxLength)
            .WithMessage(IndividualCustomerConstants.ValidationMessages.LastNameMaxLength);

        RuleFor(x => x.NationalId)
            .NotEmpty().WithMessage(IndividualCustomerConstants.ValidationMessages.NationalIdRequired)
            .Length(IndividualCustomerConstants.Rules.NationalIdLength)
            .WithMessage(IndividualCustomerConstants.ValidationMessages.NationalIdLength)
            .Must(BeNumeric).WithMessage(IndividualCustomerConstants.ValidationMessages.NationalIdInvalid);

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage(IndividualCustomerConstants.ValidationMessages.DateOfBirthRequired)
            .Must(BeValidAge).WithMessage(IndividualCustomerConstants.ValidationMessages.AgeMinimum);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage(IndividualCustomerConstants.ValidationMessages.PhoneNumberRequired)
            .MaximumLength(IndividualCustomerConstants.Rules.PhoneNumberMaxLength)
            .WithMessage(IndividualCustomerConstants.ValidationMessages.PhoneNumberInvalid);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(IndividualCustomerConstants.ValidationMessages.EmailRequired)
            .EmailAddress().WithMessage(IndividualCustomerConstants.ValidationMessages.EmailInvalid)
            .MaximumLength(IndividualCustomerConstants.Rules.EmailMaxLength)
            .WithMessage(IndividualCustomerConstants.ValidationMessages.EmailInvalid);

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(IndividualCustomerConstants.ValidationMessages.AddressRequired)
            .MaximumLength(IndividualCustomerConstants.Rules.AddressMaxLength)
            .WithMessage(IndividualCustomerConstants.ValidationMessages.AddressMaxLength);

        RuleFor(x => x.MotherName)
            .MaximumLength(IndividualCustomerConstants.Rules.MotherNameMaxLength)
            .WithMessage(IndividualCustomerConstants.ValidationMessages.MotherNameMaxLength)
            .When(x => !string.IsNullOrEmpty(x.MotherName));

        RuleFor(x => x.FatherName)
            .MaximumLength(IndividualCustomerConstants.Rules.FatherNameMaxLength)
            .WithMessage(IndividualCustomerConstants.ValidationMessages.FatherNameMaxLength)
            .When(x => !string.IsNullOrEmpty(x.FatherName));
    }

    private static bool BeNumeric(string value)
    {
        return !string.IsNullOrEmpty(value) && value.All(char.IsDigit);
    }

    private static bool BeValidAge(DateTime dateOfBirth)
    {
        var age = DateTime.Today.Year - dateOfBirth.Year;
        if (DateTime.Today.DayOfYear < dateOfBirth.DayOfYear)
            age--;

        return age >= IndividualCustomerConstants.Rules.MinimumAge && 
               age <= IndividualCustomerConstants.Rules.MaximumAge;
    }
} 