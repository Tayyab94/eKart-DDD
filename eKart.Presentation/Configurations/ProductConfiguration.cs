using eKart.Domain.products;
using eKart.Domain.Products.ValueObjects;
using eKart.Presentation.Converters.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eKart.Presentation.Constants.Constants;

namespace eKart.Presentation.Configurations
{
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(Tables.Products);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion<ProductIdConverter, ProductIdComperer>()
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(p => p.Name)
            .HasConversion<ProductNameConverter, ProductNameComperer>()
            .HasMaxLength(ProductName.MaxLength).IsRequired();

            builder.Property(p => p.Price)
            .HasConversion<ProductPriceConverter, ProductPriceComperer>()
            .HasColumnType(typeName: "decimal(18,2)")
            .IsRequired();

        }
    }
}
