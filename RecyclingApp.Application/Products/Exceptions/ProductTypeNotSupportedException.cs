using RecyclingApp.Domain.Entities.Products;
using System;
using ProductTypeContract = RecyclingApp.Application.Products.Models.ProductType;

namespace RecyclingApp.Application.Products.Exceptions;

internal class ProductTypeNotSupportedException : Exception
{
    public string Value { get; }

    public ProductTypeNotSupportedException(string value)
        : base($"ProductType {value} is not supported.")
        => Value = value;

    public static ProductTypeNotSupportedException Create(ProductType entity)
        => new(entity.ToString());

    public static ProductTypeNotSupportedException Create(ProductTypeContract contract)
        => new(contract.ToString());
}
