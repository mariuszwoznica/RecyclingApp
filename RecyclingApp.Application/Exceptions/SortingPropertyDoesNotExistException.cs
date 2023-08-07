using System;

namespace RecyclingApp.Application.Exceptions;

internal class SortingPropertyDoesNotExistException : Exception
{
    public string PropertyName { get; }

    public SortingPropertyDoesNotExistException(string propertyName)
        : base($"Sorting property {propertyName} does not exist.") 
        => PropertyName = propertyName;
}