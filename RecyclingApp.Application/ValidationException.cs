using System;
using System.Collections.Generic;

namespace RecyclingApp.Application
{
    public sealed class ValidationException : Exception
    {
        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }

        public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
        {
            ErrorsDictionary = errorsDictionary;
        }

    }
}
