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
        #region [- ctor -]

        public CategoryController()
        {
            CategoryViewModel = new CategoryViewModel();
        }
        #endregion

        #region [- props -]

        public CategoryViewModel CategoryViewModel { get; set; }
        #endregion
        
        #region [- Get_Category() -]

        [Route("wapi/[controller]/Get")]
        [Produces(MediaTypeNames.Application.Json)]
        [HttpCacheFactory(500)]
        public async Task<IActionResult> Get_Category()
        {

            var categoryList = await CategoryViewModel.Select_Category();
            return Ok(categoryList);
        }
        #endregion

        #region [- Post_Category([FromBody] JObject jObject) -]

        [Route("wapi/[controller]/Post")]
        [Consumes(MediaTypeNames.Application.Json)]
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
        #endregion

        #region [- Delete_Category([FromBody] JObject jObject) -]

        [Route("wapi/[controller]/Delete")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Delete_Category([FromBody] JObject jObject)
        {
            if (!ModelState.IsValid)
            {
                
                return BadRequest();
            }

            var category = jObject["category"].ToObject<CategoryViewModel>();

            await CategoryViewModel.Remove_Category(category);

            return Ok();
        }
        #endregion

        #region [- Put_Category([FromBody] JObject jObject) -]

        [Route("wapi/[controller]/Put")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Put_Category([FromBody] JObject jObject)
        {
            if (!ModelState.IsValid)
            {
                
                return BadRequest();
            }

            var category = jObject["category"].ToObject<CategoryViewModel>();

            await CategoryViewModel.Edit_Category(category);

            return Ok();
        }
        #endregion
    }
}
