using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductStore.Models.DomainModels.EF.DTO;
using ProductStore.Models.DomainModels.EF.POCO;

namespace ProductStore.Models.ViewModels
{
    public class CategoryViewModel
    {
        #region [- ctor -]

        public CategoryViewModel()
        {
            _categoryRepository = new CategoryRepository();
        }
        #endregion

        #region [- fields -]

        private Category _category;

        private CategoryRepository _categoryRepository { get; set; }
        #endregion

        #region [- props -]

        public int Id { get; set; }

        public string Title { get; set; }
        #endregion

        #region [- Select_Category() -]

        public async Task<List<CategoryViewModel>> Select_Category()
        {

            var categoryList = await _categoryRepository.Select();
            var categoryViewModelList = categoryList.Select(c => new CategoryViewModel()
            {

                Id = c.Id,
                Title = c.Name

            }).ToList();

            return categoryViewModelList;
        }
        #endregion

        #region [- Add_Category(CategoryViewModel categoryViewModel) -]

        public async Task Add_Category(CategoryViewModel categoryViewModel)
        {

            _category = new Category()
            {

                Name = categoryViewModel.Title
            };

            await _categoryRepository.Insert(_category);
        }
        #endregion

        #region [- Edit_Category(CategoryViewModel categoryViewModel) -]

        public async Task Edit_Category(CategoryViewModel categoryViewModel)
        {
            _category = new Category()
            {
                Id = categoryViewModel.Id,
                Name = categoryViewModel.Title
            };

            await _categoryRepository.Update(_category);
        }
        #endregion
    
        #region [- Remove_Category(CategoryViewModel categoryViewModel) -]
        public async Task Remove_Category(CategoryViewModel categoryViewModel)
        {
            _category = new Category() 
            {
                Id = categoryViewModel.Id
            };

            await _categoryRepository.Delete(_category.Id);
        }
        #endregion
    }
}
