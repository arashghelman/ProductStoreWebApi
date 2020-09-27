using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductStore.Models.DomainModels.EF.DTO.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product")
                .HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();
            builder.Property(p => p.CategoryId)
                .HasColumnName("Category_Ref");
            builder.Property(p => p.Name)
                .HasColumnName("Title")
                .IsRequired();
            builder.Property(p => p.UnitsInStock)
                .IsRequired();
            builder.Property(p => p.UnitPrice)
                .HasColumnType("money")
                .IsRequired();
            builder.Property(p => p.Discount)
                .HasColumnType("money")
                .IsRequired();
                
        }
    }
}
