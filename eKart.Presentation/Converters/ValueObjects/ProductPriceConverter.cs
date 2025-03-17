using eKart.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace eKart.Presentation.Converters.ValueObjects
{
    public sealed class ProductPriceConverter : ValueConverter<ProductPrice, decimal>
    {
        public ProductPriceConverter()
            : base(price => price.Value, value => ProductPrice.Create(value).Value)
        { }
    }

    public sealed class ProductPriceComperer : ValueComparer<ProductPrice>
    {
        public ProductPriceComperer()
            : base((price1, price2) => price1!.Value == price2!.Value,
                  price => price.Value.GetHashCode())
        { }

    }
}
