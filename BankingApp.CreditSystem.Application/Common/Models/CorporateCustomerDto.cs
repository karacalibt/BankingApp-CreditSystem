namespace BankingApp.CreditSystem.Application.Common.Models;

public class CorporateCustomerDto : CustomerDto
{
    public string CompanyName { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public string TaxOffice { get; set; } = default!;
    public string CompanyRegistrationNumber { get; set; } = default!;
    public string AuthorizedPersonName { get; set; } = default!;
    public DateTime CompanyFoundationDate { get; set; }
    public int CompanyAge => DateTime.Today.Year - CompanyFoundationDate.Year - (DateTime.Today.DayOfYear < CompanyFoundationDate.DayOfYear ? 1 : 0);
} 