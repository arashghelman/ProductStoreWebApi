using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Models.ViewModels;

namespace ProductStore.Controllers
{
    [ApiController]
    [Route("wapi/[controller]")]
    public class CategoryController : ControllerBase
    {
        public CategoryController()
        {
            CategoryViewModel = new CategoryViewModel();
        }

        public CategoryViewModel CategoryViewModel { get; set; }


        [Produces("application/json")]
        public async Task<IActionResult> Get_Category()
        {

            var categoryList = await CategoryViewModel.Select_Category();
            return Ok(categoryList);
        }
    }
}
