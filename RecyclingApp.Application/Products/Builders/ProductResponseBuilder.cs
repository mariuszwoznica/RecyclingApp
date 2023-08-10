﻿using RecyclingApp.Application.Interfaces;
using RecyclingApp.Application.Products.Models;
using RecyclingApp.Application.Products.Utilities;
using RecyclingApp.Domain.Model.Products;

namespace RecyclingApp.Application.Products.Builders;

internal class ProductResponseBuilder : IResponseBuilder<Product, ProductResponse>
{
    public ProductResponse Build(Product input)
        => new(
            Name: input.Name,
            Type: input.Type.ToContract(),
            Price: input.Price
            );
}