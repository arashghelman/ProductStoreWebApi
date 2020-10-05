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

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Get_ProductDetails([FromBody] JObject jObject) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = jObject["product"].ToObject<ProductViewModel>();

            var productDetails = await ProductViewModel.Select_ProductDetails(product);

            return Ok(productDetails);
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

        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Delete_Product([FromBody] JObject jObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = jObject["product"].ToObject<ProductViewModel>();

            await ProductViewModel.Remove_Product(product);

            return Ok();
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Put_Product([FromBody] JObject jObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = jObject["product"].ToObject<ProductViewModel>();

            await ProductViewModel.Edit_Product(product);

            return Ok();
        }
    }
}
