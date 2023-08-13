using System;
using System.Collections.Generic;

namespace RecyclingApp.Application;

public class ValidationException : Exception
{
    public IReadOnlyDictionary<string, string[]> Errors { get; }

    public ValidationException(IReadOnlyDictionary<string, string[]> errors)
        : base("Received object has invalid fields.")
        => Errors = errors;
}