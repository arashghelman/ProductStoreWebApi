using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Net.Mime;
using System.Threading.Tasks;
using CacheCow.Server.Core.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json.Linq;
using ProductStore.Models.ViewModels;

namespace ProductStore.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryController()
        {
            CategoryViewModel = new CategoryViewModel();
        }

        public CategoryViewModel CategoryViewModel { get; set; }

        [Route("wapi/[controller]/Get")]
        [Produces(MediaTypeNames.Application.Json)]
        [HttpCacheFactory(500)]
        public async Task<IActionResult> Get_Category()
        {

            var categoryList = await CategoryViewModel.Select_Category();
            return Ok(categoryList);
        }

        [Route("wapi/[controller]/Post")]
        public async Task<IActionResult> Post_Category([FromBody] JObject jObject)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var category = jObject["category"].ToObject<CategoryViewModel>();

            await CategoryViewModel.Add_Category(category);

            return Ok();
        }
    }
}
