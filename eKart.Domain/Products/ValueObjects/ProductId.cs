using eKart.Domain.Common.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart.Domain.Products.ValueObjects
{
    public sealed record class ProductId : ValueObject<Guid>
    {
        private ProductId(Guid value):base(value) { }

        public static ValidationResult<ProductId> Create(Guid value)
        {
            var errors = new List<string>();

            if (value == Guid.Empty)
                errors.Add("Product Id can't empty");

            return errors.Count==0?
                ValidationResult<ProductId>.Success(new ProductId(value)) :
                ValidationResult<ProductId>.Failure(errors);
        }

        public static ProductId newId()=> new ProductId(Guid.NewGuid());
    }
}
