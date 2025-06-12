using System;

namespace BankingApp.CreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    {
    }

    public BusinessException() : base()
    {
    }

    public BusinessException(string message, Exception innerException) : base(message, innerException)
    {
    }
} 