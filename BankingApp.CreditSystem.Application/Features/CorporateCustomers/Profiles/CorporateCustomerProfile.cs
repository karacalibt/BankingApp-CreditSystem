using AutoMapper;
using BankingApp.CreditSystem.Application.Common.Models;
using BankingApp.CreditSystem.Domain.Entities;

namespace BankingApp.CreditSystem.Application.Features.CorporateCustomers.Profiles;

public class CorporateCustomerProfile : Profile
{
    public CorporateCustomerProfile()
    {
        CreateMap<CorporateCustomer, CorporateCustomerDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<CorporateCustomer, CorporateCustomerDto>()
            .ForMember(dest => dest.CompanyAge, opt => opt.MapFrom(src => 
                DateTime.Today.Year - src.CompanyFoundationDate.Year - 
                (DateTime.Today.DayOfYear < src.CompanyFoundationDate.DayOfYear ? 1 : 0)));
    }
} 