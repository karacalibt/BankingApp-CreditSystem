using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BankingApp.CreditSystem.Application.Features.IndividualCustomers.Validators;
using BankingApp.CreditSystem.Application.Features.IndividualCustomers.Services;
using BankingApp.CreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingApp.CreditSystem.Application.Features.CorporateCustomers.Validators;
using BankingApp.CreditSystem.Application.Features.CorporateCustomers.Services;
using BankingApp.CreditSystem.Application.Features.CorporateCustomers.Rules;

namespace BankingApp.CreditSystem.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // MediatR registration
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        // AutoMapper registration
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        // Individual Customer Services (SRP compliant)
        services.AddScoped<IndividualCustomerValidator>();
        services.AddScoped<IndividualCustomerExistenceChecker>();
        services.AddScoped<IndividualCustomerBusinessRules>();
        
        // Corporate Customer Services (SRP compliant)
        services.AddScoped<CorporateCustomerValidator>();
        services.AddScoped<CorporateCustomerExistenceChecker>();
        services.AddScoped<CorporateCustomerBusinessRules>();

        return services;
    }
} 