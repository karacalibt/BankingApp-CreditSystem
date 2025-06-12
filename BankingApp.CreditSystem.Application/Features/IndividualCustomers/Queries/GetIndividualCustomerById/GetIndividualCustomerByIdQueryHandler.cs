using AutoMapper;
using BankingApp.CreditSystem.Application.Common.Models;
using BankingApp.CreditSystem.Application.Services.Repositories;
using MediatR;

namespace BankingApp.CreditSystem.Application.Features.IndividualCustomers.Queries.GetIndividualCustomerById;

public class GetIndividualCustomerByIdQueryHandler : IRequestHandler<GetIndividualCustomerByIdQuery, IndividualCustomerDto?>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;

    public GetIndividualCustomerByIdQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
    }

    public async Task<IndividualCustomerDto?> Handle(GetIndividualCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _individualCustomerRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (customer == null || customer.DeletedDate != null)
            return null;

        return _mapper.Map<IndividualCustomerDto>(customer);
    }
} 