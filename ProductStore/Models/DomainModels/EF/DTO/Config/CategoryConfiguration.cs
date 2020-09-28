using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductStore.Models.DomainModels.EF.DTO.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        #region [- ctor -]

        public CategoryConfiguration()
        {
        }
        #endregion

        #region [- Configure(EntityTypeBuilder<Category> builder) -]

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category")
                .HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Name)
                .HasColumnName("Title")
                .IsRequired();
        }
        #endregion
    }
}
