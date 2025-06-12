namespace BankingApp.CreditSystem.Application.Common.Models;

public abstract class CustomerDto : BaseDto
{
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
    public bool IsActive { get; set; }
} 