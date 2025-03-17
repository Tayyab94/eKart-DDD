using eKart.Domain.Common.Result;
using eKart.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKart.Domain.products
{

    // Product.Create(ProductId.Create(Guid.NewGuid()).Value, ProductName.Create("Product 1").Value, ProductPrice.Create(100).Value).Value
    public sealed class Product
    {
        public ProductId Id { get; private set; }
        public ProductName Name { get; private set; }

        public ProductPrice Price { get; private set; }

        public Product(ProductId id, ProductName name, ProductPrice price)
        {
            this.Id =id?? throw new ArgumentNullException(nameof(id));
            this.Name=name?? throw new ArgumentNullException(nameof(name));
            this.Price = price?? throw new ArgumentNullException(nameof(price));
        }


        public static ValidationResult<Product> Create(ProductId id, ProductName name, ProductPrice price)
        {
            var errors = new List<string>();

            if(id == null)errors.Add("Product Id is required");
            if (name == null) errors.Add("Product Name is required");
            if (price == null) errors.Add("Product Price is required");

            return errors.Count>0? ValidationResult<Product>.Failure(errors) : ValidationResult<Product>.Success(new Product(id, name, price));
        }

        public void UpdatePrice(ProductPrice newPrice)=> this.Price = newPrice?? throw new ArgumentNullException(nameof(newPrice));
    }
}
