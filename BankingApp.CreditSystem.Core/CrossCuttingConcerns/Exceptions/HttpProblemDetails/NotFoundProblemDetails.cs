using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.CreditSystem.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class NotFoundProblemDetails : ProblemDetails
{
    public NotFoundProblemDetails(string detail)
    {
        Title = "Resource not found";
        Detail = detail;
        Status = StatusCodes.Status404NotFound;
        Type = "https://example.com/probs/notfound";
        Instance = "";
    }
} 