namespace BankingApp.CreditSystem.Application.Common.Models;

public class IndividualCustomerDto : CustomerDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string NationalId { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string? MotherName { get; set; }
    public string? FatherName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public int Age => DateTime.Today.Year - DateOfBirth.Year - (DateTime.Today.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
} 