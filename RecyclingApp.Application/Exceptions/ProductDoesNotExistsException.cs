using System;

namespace RecyclingApp.Application.Exceptions;

internal class ProductDoesNotExistsException : Exception
{
    //public Guid ProductId { get; }

    public ProductDoesNotExistsException()
        : base($"Product does not exist.") { }
        //=> ProductId = productId;
}