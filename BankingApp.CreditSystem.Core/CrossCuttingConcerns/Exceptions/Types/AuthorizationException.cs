using System;

namespace BankingApp.CreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

public class AuthorizationException : Exception
{
    public AuthorizationException(string message) : base(message)
    {
    }

    public AuthorizationException() : base()
    {
    }

    public AuthorizationException(string message, Exception innerException) : base(message, innerException)
    {
    }
} 