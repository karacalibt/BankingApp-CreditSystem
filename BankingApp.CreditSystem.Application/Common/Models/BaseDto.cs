namespace BankingApp.CreditSystem.Application.Common.Models;

public abstract class BaseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
} 