using Microsoft.AspNetCore.Builder;

namespace BankingApp.CreditSystem.Core.CrossCuttingConcerns.Exceptions.Middlewares;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
} 