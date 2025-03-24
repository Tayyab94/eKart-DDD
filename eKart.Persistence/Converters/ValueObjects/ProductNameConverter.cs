using eKart.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart.Persistence.Converters.ValueObjects
{
    public sealed class ProductNameConverter: ValueConverter<ProductName, string>
    {
        public ProductNameConverter()
            : base(productName => productName.Value, @string => ProductName.Create(@string).Value)
        { }
    }


    public sealed class ProductNameComperer : ValueComparer<ProductName>
    {
        public ProductNameComperer()
            : base((name1, name2) => name1!.Value == name2!.Value,
                  name => name      .Value.GetHashCode())
        { }

    }


}
