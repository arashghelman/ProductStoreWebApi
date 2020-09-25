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
        public CategoryViewModel()
        {
            _categoryRepository = new CategoryRepository();
        }

        private Category _category;

        private CategoryRepository _categoryRepository { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

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

    }
}
