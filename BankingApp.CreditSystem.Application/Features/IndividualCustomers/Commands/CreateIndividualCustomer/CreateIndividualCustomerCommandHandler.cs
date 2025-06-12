using AutoMapper;
using BankingApp.CreditSystem.Application.Common.Models;
using BankingApp.CreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingApp.CreditSystem.Application.Services.Repositories;
using BankingApp.CreditSystem.Domain.Entities;
using MediatR;

namespace BankingApp.CreditSystem.Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;

public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, IndividualCustomerDto>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public CreateIndividualCustomerCommandHandler(
        IIndividualCustomerRepository individualCustomerRepository,
        IMapper mapper,
        IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<IndividualCustomerDto> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        // Improved SRP-compliant business rules validation
        await _businessRules.ValidateCreateRequestAsync(request);

        var customer = new IndividualCustomer
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            NationalId = request.NationalId,
            DateOfBirth = request.DateOfBirth,
            MotherName = request.MotherName,
            FatherName = request.FatherName,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            Address = request.Address,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        var createdCustomer = await _individualCustomerRepository.AddAsync(customer, cancellationToken);
        await _individualCustomerRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<IndividualCustomerDto>(createdCustomer);
    }
} 