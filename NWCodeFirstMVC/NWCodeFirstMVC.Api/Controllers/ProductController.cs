using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NWCodeFirstMVC.App.Contracts;
using NWCodeFirstMVC.Domain;
using NWCodeFirstMVC.Domain.Dto;
using NWCodeFirstMVC.Domain.Models;

namespace NWCodeFirstMVC.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly northwindContext _dc;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, northwindContext dc, IMapper mapper)
        {
            _productService = productService;
            _dc = dc;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            return Ok(_productService.GetAllProduct());
        }

        [HttpGet("{id}")]
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
            var results = _productService.GetProductWithHighQuantityOrders();

            return Ok(results);
        }

        [HttpPost("AddProduct")]
        public ActionResult AddProduct(ProductDto createproduct)
        {
            var product = mapper.Map<Product>(createproduct);
            var results = _productService.AddProduct(createproduct);
            return CreatedAtAction("GetAllProduct", new { ProductId = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product product)
        {
            if(id != product.ProductId)
            {
                return BadRequest("Invalid ID");
            }

            _dc.Entry(product).State = EntityState.Modified;

            try
            {
                _dc.SaveChanges();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(product.ProductId != id)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                   
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _dc.Products.Find(id);
           
            if (product != null)
            {
                product.IsDeleted = true;
            }
            _dc.SaveChanges();

            return NoContent();

        }
    }
}
