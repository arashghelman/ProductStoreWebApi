using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductStore.Models.DomainModels.EF.DTO;
using ProductStore.Models.DomainModels.EF.DTO.POCO;

namespace ProductStore.Models.DomainModels.EF.POCO
{
    public class CategoryRepository
    {
        #region [- ctor -]

        public CategoryRepository()
        {
        }
        #endregion

        #region [- Select() -]

        public async Task<List<Category>> Select()
        {

            await using (var context = new ProductStoreDbContext())
            {
                try
                {

                    var categoryList = await context.Categories.AsNoTracking().ToListAsync();

                    return categoryList;
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

        #region [- Insert(Category category) -]

        public async Task Insert(Category category)
        {

            await using (var context = new ProductStoreDbContext())
            {
                try
                {

                    await context.Categories.AddAsync(category);

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

        #region [- Update(Category category) -]

        public async Task Update(Category category)
        {

            await using (var context = new ProductStoreDbContext())
            {
                try
                {

                    context.Entry(category).State = EntityState.Modified;

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

                    var category = await context.Categories
                        .FirstOrDefaultAsync(c => c.Id == id);

                    context.Categories.Remove(category);

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
}
