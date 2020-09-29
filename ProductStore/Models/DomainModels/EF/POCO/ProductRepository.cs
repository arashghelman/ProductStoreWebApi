using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductStore.Models.DomainModels.EF.DTO;
using ProductStore.Models.DomainModels.EF.DTO.POCO;

public class ProductRepository
{
    public ProductRepository()
    {
        
    }

    #region [- Select() -]

        public async Task<List<Product>> Select() {
        await using (var context = new ProductStoreDbContext())
        {
            try
            {
                var categoryList = await context.Products.Include(p => p.Category)
                    .AsNoTracking()
                    .ToListAsync();
                return categoryList;
            }
            catch (Exception ex) 
            {
                
                throw ex;
            }
            finally {
                if (context != null)
                {
                    await context.DisposeAsync();
                }
            }
        }
    }
    #endregion

    #region [- Insert(Product product) -]
        
        public async Task Insert(Product product) {
        await using(var context = new ProductStoreDbContext()) 
        {
            try
            {
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                if (context != null)
                {
                    await context.DisposeAsync();
                }
            }
        }
    }
    #endregion

    #region [- Update(Product product)  -]

    public async Task Update(Product product) 
    {
        await using (var context = new ProductStoreDbContext())
        {
            try
            {
                context.Entry(product).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                if (context != null)
                {
                    await context.DisposeAsync();
                }
            }
        }
    }
    #endregion

    #region [- Delete(int? id) -]
        public async Task Delete(int? id) 
        {
            await using (var context = new ProductStoreDbContext())
            {
                try
                {
                    
                    var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
                    context.Products.Remove(product);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex) 
                {
                    
                    throw ex;
                }
                finally 
                {
                    if (context != null)
                    {
                        await context.DisposeAsync();
                    }
                }
            }
        }
    #endregion

}
