using System;

namespace RecyclingApp.Application.Products.Exceptions;

internal class ProductDoesNotExistsException : Exception
{
    public ProductDoesNotExistsException()
        : base($"Product does not exist.") { }
}