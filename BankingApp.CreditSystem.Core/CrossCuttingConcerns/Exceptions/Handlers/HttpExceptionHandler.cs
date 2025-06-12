using BankingApp.CreditSystem.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using BankingApp.CreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankingApp.CreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    public override async Task HandleExceptionAsync(HttpContext context, object exception)
    {
        await HandleExceptionTypeAsync(context, exception);
    }

    private static async Task HandleExceptionTypeAsync(HttpContext context, object exception)
    {
        switch (exception)
        {
            case BusinessException businessException:
                await HandleBusinessExceptionAsync(context, businessException);
                break;
            case ValidationException validationException:
                await HandleValidationExceptionAsync(context, validationException);
                break;
            case AuthorizationException authorizationException:
                await HandleAuthorizationExceptionAsync(context, authorizationException);
                break;
            case NotFoundException notFoundException:
                await HandleNotFoundExceptionAsync(context, notFoundException);
                break;
            default:
                await HandleDefaultExceptionAsync(context, (Exception)exception);
                break;
        }
    }

    private static Task HandleBusinessExceptionAsync(HttpContext context, BusinessException exception)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/json";

        var problemDetails = new BusinessProblemDetails(exception.Message).AsJson();
        return context.Response.WriteAsync(problemDetails);
    }

    private static Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/json";

        var problemDetails = new ValidationProblemDetails(exception.Errors).AsJson();
        return context.Response.WriteAsync(problemDetails);
    }

    private static Task HandleAuthorizationExceptionAsync(HttpContext context, AuthorizationException exception)
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Response.ContentType = "application/json";

        var problemDetails = new AuthorizationProblemDetails(exception.Message).AsJson();
        return context.Response.WriteAsync(problemDetails);
    }

    private static Task HandleNotFoundExceptionAsync(HttpContext context, NotFoundException exception)
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
        context.Response.ContentType = "application/json";

        var problemDetails = new NotFoundProblemDetails(exception.Message).AsJson();
        return context.Response.WriteAsync(problemDetails);
    }

    private static Task HandleDefaultExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        var problemDetails = new InternalServerErrorProblemDetails(exception.Message).AsJson();
        return context.Response.WriteAsync(problemDetails);
    }
} 