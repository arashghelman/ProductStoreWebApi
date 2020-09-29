using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ProductStore.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
            ProductViewModel = new ProductViewModel();
        }

        public ProductViewModel ProductViewModel { get; set; }

        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Get_Category()
        {

            var productList = await ProductViewModel.Select_Category();
            return Ok(productList);
        }

        public async Task<IActionResult> Post_Category([FromBody] JObject jObject) {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var product = jObject["product"].ToObject<ProductViewModel>();

            await ProductViewModel.Add_Category(product);

            return Ok();
        }
    }
}
