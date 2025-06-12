using AutoMapper;
using BankingApp.CreditSystem.Application.Common.Models;
using BankingApp.CreditSystem.Domain.Entities;

namespace BankingApp.CreditSystem.Application.Features.IndividualCustomers.Profiles;

public class IndividualCustomerProfile : Profile
{
    public IndividualCustomerProfile()
    {
        CreateMap<IndividualCustomer, IndividualCustomerDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<IndividualCustomer, IndividualCustomerDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => 
                DateTime.Today.Year - src.DateOfBirth.Year - 
                (DateTime.Today.DayOfYear < src.DateOfBirth.DayOfYear ? 1 : 0)));
    }
} 