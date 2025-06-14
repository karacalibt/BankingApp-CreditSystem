using System;

namespace BankingApp.CreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException() : base()
    {
    }

    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
} 