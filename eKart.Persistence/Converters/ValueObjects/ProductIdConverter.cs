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
    public sealed class ProductIdConverter :ValueConverter<ProductId, Guid>
    {
        public ProductIdConverter()
            : base(productId => productId.Value, guid => ProductId.Create(guid).Value)
        {}

    }


    public sealed class ProductIdComperer : ValueComparer<ProductId>
    {
        public ProductIdComperer()
            : base((id1, id2)=> id1!.Value == id2!.Value,
                  id=> id.Value.GetHashCode())
        { }

    }
}
