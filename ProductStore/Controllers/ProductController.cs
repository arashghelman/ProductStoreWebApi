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

        #region [- ctor -]

        public ProductController()
        {
            ProductViewModel = new ProductViewModel();
        }
        #endregion

        #region [- props -]

        public ProductViewModel ProductViewModel { get; set; }
        #endregion

        #region [- Get_Product() -]

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Get_Product()
        {

            var productList = await ProductViewModel.Select_Product();
            return Ok(productList);
        }
        #endregion

        #region [- Get_ProductDetails([FromBody] JObject jObject) -]

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

        #endregion
        
        #region [- Post_Product([FromBody] JObject jObject) -]

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
        #endregion

        #region [- Delete_Product([FromBody] JObject jObject) -]

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
        #endregion

        #region [- Put_Product([FromBody] JObject jObject) -]

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
        #endregion
    }
}
