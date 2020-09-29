using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ProductStore.Models.DomainModels.EF.DTO.POCO
{
    public class ProductStoreDbContext : DbContext
    {
        #region [- ctors -]

        public ProductStoreDbContext()
        {

        }

        public ProductStoreDbContext(DbContextOptions<ProductStoreDbContext> options)
                : base(options)
        {
            
        }
        #endregion
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        

        #region [- OnConfiguring(DbContextOptionsBuilder optionsBuilder) -]

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=tcp:127.0.0.1;Database=ProductStore;User=SA;Password=reallyStrongPwd123;");
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
