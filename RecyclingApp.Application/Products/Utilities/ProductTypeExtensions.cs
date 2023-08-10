using RecyclingApp.Application.Products.Exceptions;
using RecyclingApp.Domain.Model.Products;
using ProductTypeContract = RecyclingApp.Application.Products.Models.ProductType;

namespace RecyclingApp.Application.Products.Utilities;

internal static class ProductTypeExtensions
{
    internal static ProductType ToEntity(this ProductTypeContract contract)
        => contract switch
        {
            ProductTypeContract.LightTubesBox => ProductType.LightTubesBox,
            ProductTypeContract.LightBulbsBox => ProductType.LightBulbsBox,
            ProductTypeContract.BatteriesBox => ProductType.BatteriesBox,
            ProductTypeContract.CoffeeCapsulesBox => ProductType.CoffeeCapsulesBox,
            ProductTypeContract.eWasteBox => ProductType.eWasteBox,
            _ => throw ProductTypeNotSupportedException.Create(contract)
        };

    internal static ProductTypeContract ToContract(this ProductType entity)
        => entity switch
        {
            ProductType.LightTubesBox => ProductTypeContract.LightTubesBox,
            ProductType.LightBulbsBox => ProductTypeContract.LightBulbsBox,
            ProductType.BatteriesBox => ProductTypeContract.BatteriesBox,
            ProductType.CoffeeCapsulesBox => ProductTypeContract.CoffeeCapsulesBox,
            ProductType.eWasteBox => ProductTypeContract.eWasteBox,
            _ => throw ProductTypeNotSupportedException.Create(entity)
        };
}