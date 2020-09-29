using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ProductStore.Controllers
{
    [ApiController]
    [Route("wapi/[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
            ProductViewModel = new ProductViewModel();
        }

        public ProductViewModel ProductViewModel { get; set; }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Get_Product()
        {

            var productList = await ProductViewModel.Select_Product();
            return Ok(productList);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post_Product([FromBody] JObject jObject) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var product = jObject["product"].ToObject<ProductViewModel>();

            await ProductViewModel.Add_Product(product);

            return Ok();
        }
    }
}
