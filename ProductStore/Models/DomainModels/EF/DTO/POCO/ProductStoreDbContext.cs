using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ProductStore.Models.DomainModels.EF.DTO.POCO
{
    public class ProductStoreDbContext : DbContext
    {
        #region [- ctor -]

        public ProductStoreDbContext(DbContextOptions<ProductStoreDbContext> options)
                : base(options)
        {
        }
        #endregion


        public DbSet<Category> Categories { get; set; }

        #region [- OnConfiguring(DbContextOptionsBuilder optionsBuilder) -]

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        #endregion

        #region [- OnModelCreating(ModelBuilder modelBuilder) -]

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        #endregion
    }
}
