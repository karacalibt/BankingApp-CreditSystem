using BankingApp.CreditSystem.Application.Common.Models;
using MediatR;

namespace BankingApp.CreditSystem.Application.Features.IndividualCustomers.Queries.GetIndividualCustomerById;

public class GetIndividualCustomerByIdQuery : IRequest<IndividualCustomerDto?>
{
    public Guid Id { get; set; }

    public GetIndividualCustomerByIdQuery(Guid id)
    {
        Id = id;
    }
} 