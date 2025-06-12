using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BankingApp.CreditSystem.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public static class ProblemDetailsExtensions
{
    public static string AsJson<TProblemDetail>(this TProblemDetail details) 
        where TProblemDetail : ProblemDetails
    {
        return JsonSerializer.Serialize(details);
    }

    public static IActionResult AsResponse<TProblemDetail>(this TProblemDetail details) 
        where TProblemDetail : ProblemDetails
    {
        return new ObjectResult(details)
        {
            StatusCode = details.Status
        };
    }
} 