using eKart.Domain.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart.Domain.Products.ValueObjects
{
    public sealed record class ProductName: ValueObject<string>
    {
        public const int MaxLength = 100;
        private ProductName(string value) : base(value) { }

        public static ValidationResult<ProductName> Create(string value)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(value))
                errors.Add("Product Name can't empty");
            if(value.Length> MaxLength)
                errors.Add($"Product Name can't be more than {MaxLength} characters");

            return errors.Count == 0 ?
                ValidationResult<ProductName>.Success(new ProductName(value)) :
                ValidationResult<ProductName>.Failure(errors);
        }
    }
}
