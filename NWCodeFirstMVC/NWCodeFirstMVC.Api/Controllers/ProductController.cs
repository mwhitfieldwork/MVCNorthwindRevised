using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWCodeFirstMVC.App.Contracts;
using NWCodeFirstMVCSacffold.Models;

namespace NWCodeFirstMVC.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProd")]
        public IActionResult GetAllProduct()
        {
            return Ok(_productService.GetAllProduct());
        }

        [HttpGet("GetProd/{id:int}")]
        public IActionResult GetAProduct(int id)
        {
            var product = _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpGet("GetLuxUsProd")]
        public IActionResult GetLuxuryUSProduct() //IActionResult returns the json data
        {
            //returning a response ( ok, 404, ect) 
            // use the inteface which is used a  service
            return Ok(_productService.GetLuxuryUSProduct()); 
        }

        [HttpGet("GetProdOrders")]
        public IActionResult GetProdOrders() //IActionResult returns the json data
        {
            //returning a response ( ok, 404, ect) 
            // use the inteface which is used a  service
            return Ok(_productService.GetProductWithHighQuantityOrders());
        }

        [HttpPost("AddProduct")]
        public ActionResult AddProduct(Product product)
        {
            var results = _productService.AddProduct(product);
            return CreatedAtAction("GetAllProduct", new { ProductId = product.ProductId }, product);
        }
    }
}
