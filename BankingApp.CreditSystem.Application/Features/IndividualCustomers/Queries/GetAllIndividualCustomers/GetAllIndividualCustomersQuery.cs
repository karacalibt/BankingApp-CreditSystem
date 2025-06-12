using BankingApp.CreditSystem.Application.Common.Models;
using BankingApp.CreditSystem.Core.Repositories;
using MediatR;

namespace BankingApp.CreditSystem.Application.Features.IndividualCustomers.Queries.GetAllIndividualCustomers;

public class GetAllIndividualCustomersQuery : IRequest<PagedResult<IndividualCustomerDto>>
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }
    public bool? IsActive { get; set; }
} 