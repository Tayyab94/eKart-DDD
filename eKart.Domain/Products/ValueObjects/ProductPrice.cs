using eKart.Domain.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart.Domain.Products.ValueObjects
{
    
    public sealed record class ProductPrice : ValueObject<decimal>
    {
        private ProductPrice(decimal value) : base(value) { }

        public static ValidationResult<ProductPrice> Create(decimal value)
        {
            var errors = new List<string>();

            if (value<0)
                errors.Add("Product Price can't be negative");

            return errors.Count == 0 ?
                ValidationResult<ProductPrice>.Success(new ProductPrice(value)) :
                ValidationResult<ProductPrice>.Failure(errors);
        }
    }
}
