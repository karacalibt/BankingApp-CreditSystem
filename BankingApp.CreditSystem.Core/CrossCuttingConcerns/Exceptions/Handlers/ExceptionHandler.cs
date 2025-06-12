using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace BankingApp.CreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        return Task.CompletedTask;
    }

    public abstract Task HandleExceptionAsync(HttpContext context, object exception);
} 