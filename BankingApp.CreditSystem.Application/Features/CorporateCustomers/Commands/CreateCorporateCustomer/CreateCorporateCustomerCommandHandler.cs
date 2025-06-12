using AutoMapper;
using BankingApp.CreditSystem.Application.Common.Models;
using BankingApp.CreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingApp.CreditSystem.Application.Services.Repositories;
using BankingApp.CreditSystem.Domain.Entities;
using MediatR;

namespace BankingApp.CreditSystem.Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;

public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CorporateCustomerDto>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly IMapper _mapper;
    private readonly CorporateCustomerBusinessRules _businessRules;

    public CreateCorporateCustomerCommandHandler(
        ICorporateCustomerRepository corporateCustomerRepository,
        IMapper mapper,
        CorporateCustomerBusinessRules businessRules)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<CorporateCustomerDto> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.CheckIfTaxNumberExistsAsync(request.TaxNumber);
        await _businessRules.CheckIfEmailExistsAsync(request.Email);
        await _businessRules.CheckIfPhoneNumberExistsAsync(request.PhoneNumber);
        await _businessRules.CheckIfRegistrationNumberExistsAsync(request.CompanyRegistrationNumber);

        _businessRules.ValidateTaxNumber(request.TaxNumber);
        _businessRules.CheckCompanyAge(request.CompanyFoundationDate);

        var customer = new CorporateCustomer
        {
            Id = Guid.NewGuid(),
            CompanyName = request.CompanyName,
            TaxNumber = request.TaxNumber,
            TaxOffice = request.TaxOffice,
            CompanyRegistrationNumber = request.CompanyRegistrationNumber,
            AuthorizedPersonName = request.AuthorizedPersonName,
            CompanyFoundationDate = request.CompanyFoundationDate,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            Address = request.Address,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        var createdCustomer = await _corporateCustomerRepository.AddAsync(customer, cancellationToken);
        await _corporateCustomerRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CorporateCustomerDto>(createdCustomer);
    }
} 